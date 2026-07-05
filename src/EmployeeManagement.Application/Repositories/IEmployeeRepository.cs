using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Repositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllAsync();

    Task<Employee?> GetByIdAsync(int id);

    Task AddAsync(Employee employee);

    Task UpdateAsync(Employee employee);

    Task DeleteAsync(Employee employee);

    Task<IEnumerable<Employee>> GetByDepartmentAsync(int departmentId);

    Task<int> SaveChangesAsync();
}