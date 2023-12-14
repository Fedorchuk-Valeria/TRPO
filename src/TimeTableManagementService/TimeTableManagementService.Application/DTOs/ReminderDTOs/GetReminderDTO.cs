namespace TimetableManagement.Application.DTOs.ReminderDTOs;

public class GetReminderDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }
}
