using EmployeeManagement.Application.Services;
using EmployeeManagement.Application.Services.Bonus;
using EmployeeManagement.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();

        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IJwtTokenService, JwtTokenService>();

        services.AddScoped<BonusStrategyFactory>();

        return services;
    }
}