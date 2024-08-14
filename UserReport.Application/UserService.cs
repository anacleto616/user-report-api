namespace UserReport.Application;

using System.Threading.Tasks;
using Newtonsoft.Json;
using UserReport.Application.Interfaces;
using UserReport.Domain;
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

    public async Task<List<UserDto>> AddUsers(int numberOfUsers)
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

            using var transaction = await this.dbContext.Database.BeginTransactionAsync();
            try
            {
                await this.dbContext.AddRangeAsync(users);

                await this.dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return users.Select(user => user.ToDto()).ToList();
            }
            catch (Exception ex)
            {
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

    public async Task<List<User>> GetAllUsersAsync()
    {
        try
        {
            var users = await this.userPersist.GetAllUsersAsync();
            if (users == null)
            {
                return null;
            }

            return users;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
