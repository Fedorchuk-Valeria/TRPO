namespace TimetableManagement.Application.DTOs.Goal;

public class GetGoalDTO
{
    public int Id { get; set; }

    public string GoalTitle { get; set; } = string.Empty;

    public DateTime FinishDate { get; set; }

    public int UserId { get; set; }
}
