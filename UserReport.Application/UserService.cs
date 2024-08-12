﻿namespace UserReport.Application;

using System.Threading.Tasks;
using Newtonsoft.Json;
using UserReport.Application.Interfaces;
using UserReport.Domain.DTOs;
using UserReport.Domain.Mappings;
using UserReport.Persistence.Contexts;
using UserReport.Persistence.Interfaces;

public class UserService(
    IUserPersist userPersist,
    IHttpClientFactory httpClientFactory,
    UserReportContext dbContext
) : IUserService
{
    private readonly IUserPersist userPersist = userPersist;
    private readonly UserReportContext dbContext = dbContext;

    private readonly HttpClient httpClient = httpClientFactory.CreateClient("IRandomUserApi");

    public async Task<List<UserDto?>?> AddUsers(int numberOfUsers)
    {
        try
        {
            var url = $"/api/?results={numberOfUsers}";
            var response = await this.httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<RandomUserResponseDto>(json);

            if (apiResponse?.Results == null || apiResponse.Results.Count == 0)
            {
                throw new InvalidOperationException("API response does not contain any results.");
            }

            var users = apiResponse.Results.Select(apiUser => apiUser.ToEntity()).ToList();

            // Início da transação
            using var transaction = await this.dbContext.Database.BeginTransactionAsync();
            try
            {
                // Adiciona todos os usuários ao contexto
                await this.dbContext.AddRangeAsync(users);

                // Salva todas as alterações em uma única operação
                await this.dbContext.SaveChangesAsync();

                // Commit da transação se tudo ocorrer bem
                await transaction.CommitAsync();

                // Converte e retorna os DTOs dos usuários adicionados
                return users.Select(user => user.ToDto()).ToList();
            }
            catch (Exception ex)
            {
                // Rollback da transação se qualquer erro ocorrer
                await transaction.RollbackAsync();
                Console.WriteLine($"Error Details: {ex}");
                throw new InvalidOperationException(
                    "An error occurred while processing the request.",
                    ex
                );
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Details: {ex}");
            throw new InvalidOperationException(
                "An error occurred while processing the request.",
                ex
            );
        }
    }
}
