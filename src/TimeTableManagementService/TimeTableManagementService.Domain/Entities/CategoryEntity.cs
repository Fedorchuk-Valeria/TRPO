namespace TimetableManagement.Domain.Entities;

public class CategoryEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int UserId { get; set; }

    public UserEntity User { get; set; } = default!;

    public List<TaskEntity> Tasks { get; set; } = default!;

    public List<NoteEntity> Notes { get; set; } = default!;
}
