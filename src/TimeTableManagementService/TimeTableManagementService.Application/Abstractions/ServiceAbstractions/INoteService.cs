using TimetableManagement.Application.DTOs.Goal;

namespace TimetableManagement.Application.Abstractions.ServiceAbstractions;

public interface INoteService
{
    Task<List<GetUpdateNoteDTO>?> GetAllByUserCategoryAsync(int categoryId, int userId);

    Task<List<GetUpdateNoteDTO>?> GetAllByUserIdAsync(int userId);

    Task<GetUpdateNoteDTO> GetByIdAndUserIdAsync(int id, int userId);

    Task<GetUpdateNoteDTO> AddAsync(AddNoteDTO dto, int userId);

    Task<bool> RemoveByIdAndUserIdAsync(int id, int userId);
}
