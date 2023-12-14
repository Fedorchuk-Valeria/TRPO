using TimetableManagement.Domain.Enumerations;

namespace TimetableManagement.Application.DTOs.TaskDTOs;

public class GetTaskDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public TaskType TaskType { get; set; }

    public DateTime StartDate { get; set; }

    public TimeSpan Duration { get; set; }

    public int RepeatPeriod { get; set; } = 0; //days

    public int CategoryId { get; set; }
}
