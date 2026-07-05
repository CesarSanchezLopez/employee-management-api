using BCrypt.Net;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Repositories;
using EmployeeManagement.Application.Services.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Application.Services;

public class AuthService : IAuthService
{
    private readonly IAppUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthService(
        IAppUserRepository userRepository,
        IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<AuthResponseDto> RegisterAsync(AuthRequestDto request)
    {
        var existingUser = await _userRepository
            .GetByUsernameAsync(request.Username);

        if (existingUser != null)
            throw new Exception("Username already exists.");

        var user = new AppUser
        {
            Username = request.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = UserRole.User
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        var token = _jwtTokenService.GenerateToken(user);

        return new AuthResponseDto
        {
            Token = token,
            Username = user.Username,
            Role = user.Role.ToString()
        };
    }

    public async Task<AuthResponseDto> LoginAsync(AuthRequestDto request)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);

        if (user == null)
            throw new UnauthorizedAccessException("Invalid username or password.");
        // throw new Exception("Invalid username or password.");

        var validPassword = BCrypt.Net.BCrypt.Verify(
            request.Password,
            user.PasswordHash);

        if (!validPassword)
            throw new Exception("Invalid username or password.");

        var token = _jwtTokenService.GenerateToken(user);

        return new AuthResponseDto
        {
            Token = token,
            Username = user.Username,
            Role = user.Role.ToString()
        };
    }
}