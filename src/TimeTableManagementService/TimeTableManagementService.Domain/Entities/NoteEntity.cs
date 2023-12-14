using TimetableManagement.Domain.Entities;

public class NoteEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Text { get; set; } = string.Empty;

    public CategoryEntity Category { get; set; } = default!;

    public int CategoryId { get; set; }
}
