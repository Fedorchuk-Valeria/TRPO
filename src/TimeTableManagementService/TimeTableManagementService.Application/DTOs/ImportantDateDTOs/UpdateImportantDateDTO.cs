namespace TimetableManagement.Application.DTOs.Goal;

public class UpdateImportantDateDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime DateTime { get; set; } // date and reminder time
}
