using EmployeeManagement.Application.DTOs;

namespace EmployeeManagement.Application.Services.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllAsync();

    Task<EmployeeDto?> GetByIdAsync(int id);

    Task<EmployeeDto> CreateAsync(EmployeeRequestDto dto);

    Task<bool> UpdateAsync(int id, EmployeeRequestDto dto);

    Task<bool> DeleteAsync(int id);

    Task<IEnumerable<EmployeeDto>> GetByDepartmentAsync(int departmentId);

}
