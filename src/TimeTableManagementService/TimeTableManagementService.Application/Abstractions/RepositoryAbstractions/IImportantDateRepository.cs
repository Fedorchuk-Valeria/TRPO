using TimetableManagement.Domain.Entities;

namespace TimetableManagement.Application.Abstractions.RepositoryAbstractions;

public interface IImportantDateRepository : IGenericRepository<ImportantDateEntity>
{
    Task<List<ImportantDateEntity>> GetAllByUserId(int userId);
}
