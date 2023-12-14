using TimetableManagement.Application.DTOs.CategoryDTOs;

namespace TimetableManagement.Application.Abstractions.ServiceAbstractions;

public interface ICategoryService
{
    Task<GetCategoryDTO?> GetByIdAndUserIdAsync(int id, int userId);

    Task<List<GetCategoryDTO>?> GetAllByUserIdAsync(int userId);

    Task<GetCategoryDTO?> AddAsync(string name, int userId);

    Task<bool> RemoveByIdAndUserIdAsync(int id, int userId);
}
