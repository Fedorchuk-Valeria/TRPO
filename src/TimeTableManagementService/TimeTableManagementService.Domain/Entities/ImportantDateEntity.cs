namespace TimetableManagement.Domain.Entities;

public class ImportantDateEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime DateTime { get; set; } // date and reminder time

    public int UserId { get; set; }

    public UserEntity User { get; set; } = default!;
}
