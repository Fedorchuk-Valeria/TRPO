namespace TimetableManagement.Domain.Entities;

public class GoalEntity
{
    public int Id { get; set; }

    public string GoalTitle { get; set; } = string.Empty;

    public DateTime FinishDate { get; set; }

    public UserEntity User { get; set; } = default!;

    public int UserId { get; set; }
}
