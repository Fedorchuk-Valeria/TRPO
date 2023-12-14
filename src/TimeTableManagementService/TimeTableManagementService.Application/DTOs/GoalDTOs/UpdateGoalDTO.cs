namespace TimetableManagement.Application.DTOs.Goal;

public class UpdateGoalDTO
{
    public int Id { get; set; }

    public string GoalTitle { get; set; } = string.Empty;

    public DateTime FinishDate { get; set; }
}
