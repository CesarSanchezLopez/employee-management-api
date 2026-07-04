using EmployeeManagement.Application.DTOs;

namespace EmployeeManagement.Application.Services.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllAsync();

    Task<EmployeeDto?> GetByIdAsync(int id);

    Task<EmployeeDto> CreateAsync(EmployeeDto employeeDto);

    Task<bool> UpdateAsync(int id, EmployeeDto employeeDto);

    Task<bool> DeleteAsync(int id);
}