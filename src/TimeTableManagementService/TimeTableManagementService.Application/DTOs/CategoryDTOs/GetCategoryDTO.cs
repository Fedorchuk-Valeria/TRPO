namespace TimetableManagement.Application.DTOs.CategoryDTOs;

public class GetCategoryDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int UserId { get; set; }
}
