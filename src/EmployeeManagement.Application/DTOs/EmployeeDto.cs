using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Application.DTOs;

public class EmployeeDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }

    public string Department { get; set; } = string.Empty;

    public int CurrentPositionId { get; set; }

    public string CurrentPosition { get; set; } = string.Empty;

    public decimal Bonus { get; set; }

    public List<string> Projects { get; set; } = new();

    public List<PositionHistoryDto> PositionHistory { get; set; } = new();
}