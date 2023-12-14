namespace TimetableManagement.Application.DTOs.ReminderDTOs;

public class AddReminderDTO
{
    public string Name { get; set; } = string.Empty;

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }
}
