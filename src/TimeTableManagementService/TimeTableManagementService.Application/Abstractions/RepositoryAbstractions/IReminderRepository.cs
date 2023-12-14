using TimetableManagement.Domain.Entities;

namespace TimetableManagement.Application.Abstractions.RepositoryAbstractions;

public interface IReminderRepository : IGenericRepository<ReminderEntity>
{
    Task<List<int>> GetIdsByUserId(int userId);
}
