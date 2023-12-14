namespace TimetableManagement.Application.DTOs.TaskDTOs;

public class AddRecurringTaskDTO
{
    public string Name { get; set; } = string.Empty;

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public int RepeatPeriod { get; set; } //days

    public int CategoryId { get; set; }
}
