namespace TimetableManagement.Application.DTOs.TaskDTOs;

public class AddExactTimeTaskDTO
{
    public string Name { get; set; } = string.Empty;

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public int CategoryId { get; set; }
}
