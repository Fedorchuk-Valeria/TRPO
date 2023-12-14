namespace TimetableManagement.Application.DTOs.UserDTOs;

public class GetUserDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int MoneyCount { get; set; }
}
