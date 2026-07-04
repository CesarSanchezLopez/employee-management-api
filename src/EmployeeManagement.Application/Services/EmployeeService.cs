using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Repositories;
using EmployeeManagement.Application.Services.Interfaces;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();

        return employees.Select(MapToDto);
    }

    public async Task<EmployeeDto?> GetByIdAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);

        if (employee == null)
            return null;

        return MapToDto(employee);
    }

    public async Task<EmployeeDto> CreateAsync(EmployeeDto dto)
    {
        var employee = new Employee
        {
            Name = dto.Name,
            DepartmentId = dto.DepartmentId,
            CurrentPosition = dto.CurrentPosition,
            Salary = dto.Salary
        };

        await _employeeRepository.AddAsync(employee);
        await _employeeRepository.SaveChangesAsync();

        return MapToDto(employee);
    }

    public async Task<bool> UpdateAsync(int id, EmployeeDto dto)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);

        if (employee == null)
            return false;

        employee.Name = dto.Name;
        employee.DepartmentId = dto.DepartmentId;
        employee.CurrentPosition = dto.CurrentPosition;
        employee.Salary = dto.Salary;

        await _employeeRepository.UpdateAsync(employee);
        await _employeeRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);

        if (employee == null)
            return false;

        await _employeeRepository.DeleteAsync(employee);
        await _employeeRepository.SaveChangesAsync();

        return true;
    }

    private static EmployeeDto MapToDto(Employee employee)
    {
        return new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.Name,
            DepartmentId = employee.DepartmentId,
            Department = employee.Department?.Name ?? string.Empty,
            CurrentPosition = employee.CurrentPosition,
            Salary = employee.Salary,

            Projects = employee.EmployeeProjects?
                .Select(ep => ep.Project.Name)
                .ToList() ?? new List<string>(),

            PositionHistory = employee.PositionHistories?
                .Select(ph => new PositionHistoryDto
                {
                    Position = ph.Position,
                    StartDate = ph.StartDate,
                    EndDate = ph.EndDate
                })
                .ToList() ?? new List<PositionHistoryDto>()
        };
    }
}