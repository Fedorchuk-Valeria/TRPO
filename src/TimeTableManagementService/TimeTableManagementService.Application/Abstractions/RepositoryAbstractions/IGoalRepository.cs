using TimetableManagement.Domain.Entities;

namespace TimetableManagement.Application.Abstractions.RepositoryAbstractions;

public interface IGoalRepository : IGenericRepository<GoalEntity>
{
    Task<List<GoalEntity>> GetAllByUserId(int userId);
}
