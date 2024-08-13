namespace UserReport.API.Controllers;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserReport.Application.Interfaces;

[ApiController]
[Route("api/users")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService userService = userService;

    [HttpGet]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        try
        {
            var users = await this.userService.GetAllUsersAsync();
            if (users == null)
            {
                return this.NotFound();
            }

            return this.Ok(users);
        }
        catch (Exception ex)
        {
            return this.StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
