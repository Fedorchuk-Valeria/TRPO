namespace TimetableManagement.Application.DTOs.TaskDTOs;

public class AddDateOnlyTaskDTO
{
    public string Name { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public TimeSpan Duration { get; set; }

    public int CategoryId { get; set; }
}
