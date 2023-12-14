using TimetableManagement.Domain.Enumerations;

namespace TimetableManagement.Domain.Entities;

public class TaskEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public TaskType TaskType { get; set; }

    public DateTime StartDate { get; set; }

    public TimeSpan Duration { get; set; }

    public int RepeatPeriod { get; set; } = 0; //days

    public CategoryEntity Category { get; set; } = default!;

    public int CategoryId { get; set; }
}
