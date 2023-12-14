namespace TimetableManagement.Application.DTOs.Goal;

public class AddImportantDateDTO
{
    public string Name { get; set; } = string.Empty;

    public DateTime DateTime { get; set; } // date and reminder time
}
