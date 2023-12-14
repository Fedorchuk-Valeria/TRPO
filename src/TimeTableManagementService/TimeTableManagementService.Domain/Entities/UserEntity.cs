namespace TimetableManagement.Domain.Entities;

public class UserEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public List<CategoryEntity>? Category { get; set; }

    public List<GoalEntity>? Goals { get; set; }

    public List<ReminderEntity>? Reminders { get; set; }

    public List<ImportantDateEntity>? ImportantDates { get; set; }
}
