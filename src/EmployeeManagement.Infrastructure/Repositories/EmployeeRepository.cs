using EmployeeManagement.Application.Repositories;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees
            .Include(e => e.Department)
            .Include(e => e.EmployeeProjects)
                .ThenInclude(ep => ep.Project)
            .Include(e => e.PositionHistories)
            .ToListAsync();
    }
    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _context.Employees
            .Include(e => e.Department)
            .Include(e => e.EmployeeProjects)
                .ThenInclude(ep => ep.Project)
            .Include(e => e.PositionHistories)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
    }

    public Task UpdateAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Employee employee)
    {
        _context.Employees.Remove(employee);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<Employee>> GetByDepartmentAsync(int departmentId)
    {
        return await _context.Employees
            .Include(e => e.Department)
            .Include(e => e.EmployeeProjects)
                .ThenInclude(ep => ep.Project)
            .Include(e => e.PositionHistories)
            .Where(e => e.DepartmentId == departmentId)
            .Where(e => e.EmployeeProjects.Any())
            .ToListAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}