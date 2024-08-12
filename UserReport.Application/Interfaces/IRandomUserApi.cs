namespace UserReport.Application.Interfaces;

using System.Threading.Tasks;
using UserReport.Domain.DTOs;

public interface IRandomUserApi
{
    Task<RandomUserResponseDto> GetRandomUserAsync();
}
