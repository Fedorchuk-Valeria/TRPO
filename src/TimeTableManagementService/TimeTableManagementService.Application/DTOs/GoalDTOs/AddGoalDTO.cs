namespace TimetableManagement.Application.DTOs.Goal;

public class AddGoalDTO
{
    public string GoalTitle { get; set; } = string.Empty;

    public DateTime FinishDate { get; set; }
}
