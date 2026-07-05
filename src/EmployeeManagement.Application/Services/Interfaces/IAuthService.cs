using EmployeeManagement.Application.DTOs;

namespace EmployeeManagement.Application.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(AuthRequestDto request);

    Task<AuthResponseDto> LoginAsync(AuthRequestDto request);
}