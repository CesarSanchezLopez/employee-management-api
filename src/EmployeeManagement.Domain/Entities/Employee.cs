using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Domain.Entities;

public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public PositionType CurrentPosition { get; set; }

    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }

    public Department Department { get; set; } = null!;

    public ICollection<PositionHistory> PositionHistories { get; set; } = new List<PositionHistory>();

    public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
}