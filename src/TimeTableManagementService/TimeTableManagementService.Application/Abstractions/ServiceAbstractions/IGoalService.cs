using TimetableManagement.Application.DTOs.Goal;

namespace TimetableManagement.Application.Abstractions.ServiceAbstractions;

public interface IGoalService
{
    Task<List<GetGoalDTO>?> GetAllByUserIdAsync(int userId);

    Task<GetGoalDTO?> AddAsync(AddGoalDTO dto, int userId);

    Task<GetGoalDTO?> UpdateAsync(UpdateGoalDTO dto, int userId);

    Task<bool> RemoveByIdAndUserIdAsync(int id, int userId);
}
