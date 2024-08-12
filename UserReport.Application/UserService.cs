namespace UserReport.Application;

using System.Threading.Tasks;
using Newtonsoft.Json;
using UserReport.Application.Interfaces;
using UserReport.Domain.DTOs;
using UserReport.Domain.Mappings;
using UserReport.Persistence.Interfaces;

public class UserService(
    IUserPersist userPersist,
    // IRandomUserApi randomUserApi,
    IHttpClientFactory httpClientFactory
) : IUserService
{
    private readonly IUserPersist userPersist = userPersist;

    private readonly HttpClient httpClient = httpClientFactory.CreateClient("IRandomUserApi");

    public async Task<UserDto?> AddUser()
    {
        try
        {
            var response = await this.httpClient.GetAsync("/api/");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<RandomUserResponseDto>(json);
            var apiUser = apiResponse?.Results.FirstOrDefault();

            if (apiUser == null)
            {
                return null;
            }

            // Mapeia os dados do JSON da API para o objeto User
            var userDto = new UserDto(
                apiUser.Gender,
                apiUser.Name,
                apiUser.Location,
                apiUser.Email,
                apiUser.Login,
                apiUser.Dob,
                apiUser.Registered,
                apiUser.Phone,
                apiUser.Cell,
                apiUser.Id,
                apiUser.Picture,
                apiUser.Nat
            );

            var user = userDto.ToEntity();

            // Adiciona o usuário ao contexto
            this.userPersist.Add(user);

            // Salva as alterações de forma assíncrona
            if (await this.userPersist.SaveChangesAsync())
            {
                var toDto = await this.userPersist.GetUserByIdAsync(user.UserId);
                return toDto?.ToDto();
            }

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
