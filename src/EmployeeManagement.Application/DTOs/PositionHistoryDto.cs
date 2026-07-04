namespace EmployeeManagement.Application.DTOs;

public class PositionHistoryDto
{
    public string Position { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}