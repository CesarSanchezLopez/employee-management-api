using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Repositories;

public interface IAppUserRepository
{
    Task<AppUser?> GetByUsernameAsync(string username);

    Task AddAsync(AppUser user);

    Task<int> SaveChangesAsync();
}