using TimetableManagement.Application.DTOs.TaskDTOs;
using TimetableManagement.Domain.Entities;

namespace TimetableManagement.Application.Abstractions.RepositoryAbstractions;

public interface ITaskRepository : IGenericRepository<TaskEntity>
{
    Task<TaskEntity> AddAsync(TaskEntity entity);

    Task<List<TaskEntity>> GetAllByUserCategoryAndPeriodAsync(DateTime startdate, DateTime endDate, int categoryId, int userId);

    Task<List<TaskEntity>> GetAllByUserIdAndPeriodAsync(DateTime startdate, DateTime endDate, int userId);

    Task<TaskEntity?> GetByIdAndUserIdAsync(int id, int userId);
}
