using EmployeeManagement.Application.Repositories;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories;

public class AppUserRepository : IAppUserRepository
{
    private readonly ApplicationDbContext _context;

    public AppUserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<AppUser?> GetByUsernameAsync(string username)
    {
        return await _context.AppUsers
            .FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task AddAsync(AppUser user)
    {
        await _context.AppUsers.AddAsync(user);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}