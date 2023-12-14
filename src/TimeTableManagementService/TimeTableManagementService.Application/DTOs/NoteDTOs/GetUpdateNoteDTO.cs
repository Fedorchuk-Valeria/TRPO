namespace TimetableManagement.Application.DTOs.Goal;

public class GetUpdateNoteDTO
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Text { get; set; } = string.Empty;

    public int CategoryId { get; set; }
}
