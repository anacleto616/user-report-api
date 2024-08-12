namespace UserReport.Application.Interfaces;

using UserReport.Domain.DTOs;

public interface IUserService
{
    Task<List<UserDto?>?> AddUsers(int numberOfUsers);
}
