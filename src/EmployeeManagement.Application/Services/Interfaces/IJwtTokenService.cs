using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Services.Interfaces;


public interface IJwtTokenService
{
    string GenerateToken(AppUser user);
}