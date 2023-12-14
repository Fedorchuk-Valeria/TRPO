using TimetableManagement.Application.DTOs.Goal;

namespace TimetableManagement.Application.Abstractions.ServiceAbstractions;

public interface IImportantDateService
{
    Task<List<GetImportantDateDTO>?> GetAllByUserIdAsync(int userId);

    Task<GetImportantDateDTO?> AddAsync(AddImportantDateDTO dto, int userId);

    Task<GetImportantDateDTO?> UpdateAsync(UpdateImportantDateDTO dto, int userId);

    Task<bool> RemoveByIdAndUserIdAsync(int id, int userId);
}
