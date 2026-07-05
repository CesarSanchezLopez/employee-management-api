using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Repositories;
using EmployeeManagement.Application.Services.Bonus;
using EmployeeManagement.Application.Services.Interfaces;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    private readonly BonusStrategyFactory _bonusStrategyFactory;

    public EmployeeService(
     IEmployeeRepository employeeRepository,
     BonusStrategyFactory bonusStrategyFactory)
    {
        _employeeRepository = employeeRepository;
        _bonusStrategyFactory = bonusStrategyFactory;
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

    public async Task<EmployeeDto> CreateAsync(EmployeeRequestDto dto)
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

    public async Task<bool> UpdateAsync(int id, EmployeeRequestDto dto)
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

    public async Task<IEnumerable<EmployeeDto>> GetByDepartmentAsync(int departmentId)
    {
        var employees = await _employeeRepository.GetByDepartmentAsync(departmentId);

        return employees.Select(MapToDto);
    }

    private EmployeeDto MapToDto(Employee employee)
    {
        var strategy = _bonusStrategyFactory.Create(employee.CurrentPosition);
        var bonus = strategy.CalculateBonus(employee.Salary);

        return new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.Name,
            Salary = employee.Salary,

            DepartmentId = employee.DepartmentId,
            Department = employee.Department?.Name ?? string.Empty,

            CurrentPositionId = (int)employee.CurrentPosition,
            CurrentPosition = employee.CurrentPosition.ToString(),

            Bonus = bonus,

            Projects = employee.EmployeeProjects
                .Select(ep => ep.Project.Name)
                .ToList(),

            PositionHistory = employee.PositionHistories
                .Select(ph => new PositionHistoryDto
                {
                    Position = ph.Position,
                    StartDate = ph.StartDate,
                    EndDate = ph.EndDate
                })
                .ToList()
        };
    }
}