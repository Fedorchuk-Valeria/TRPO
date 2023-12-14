using TimetableManagement.Application.DTOs.TaskDTOs;

namespace TimetableManagement.Application.Abstractions.ServiceAbstractions;

public interface ITaskService
{
    Task<List<GetTaskDTO>> GetAllByUserCategoryAndPeriodAsync(DateTime startDate, DateTime endDate, int categoryId, int userId);

    Task<List<GetTaskDTO>> GetAllByUserIdAndPeriodAsync(DateTime startDate, DateTime endDate, int userId);

    Task<GetTaskDTO?> GetByIdAndUserIdAsync(int id, int userId);

    Task<GetTaskDTO?> AddExactTimeTaskAsync(AddExactTimeTaskDTO dto, int userId);

    Task<GetTaskDTO?> AddDateOnlyTaskAsync(AddDateOnlyTaskDTO dto, int userId);

    Task<GetTaskDTO?> AddRecurringTaskAsync(AddRecurringTaskDTO dto, int userId);

    Task<bool> RemoveByIdAndUserIdAsync(int id, int userId);
}
