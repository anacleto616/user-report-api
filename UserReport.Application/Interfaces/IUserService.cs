namespace UserReport.Application.Interfaces;

using UserReport.Domain.DTOs;

public interface IUserService
{
    Task<UserDto?> AddUser();
}
