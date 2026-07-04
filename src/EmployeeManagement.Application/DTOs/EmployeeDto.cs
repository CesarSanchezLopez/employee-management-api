using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Application.DTOs;

public class EmployeeDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Salary { get; set; }

    public PositionType CurrentPosition { get; set; }

    public int DepartmentId { get; set; }

    public string Department { get; set; } = string.Empty;

    public List<string> Projects { get; set; } = new();

    public List<PositionHistoryDto> PositionHistory { get; set; } = new();
}