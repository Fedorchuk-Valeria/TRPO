using TimetableManagement.Domain.Entities;

namespace TimetableManagement.Application.Abstractions.RepositoryAbstractions;

public interface INoteRepository : IGenericRepository<NoteEntity>
{
    Task<List<NoteEntity>> GetAllByUserCategoryAsync(int categoryId, int userId);

    Task<List<NoteEntity>> GetAllByUserIdAsync(int userId);

    Task<NoteEntity?> GetByIdAndUserIdAsync(int id, int userId);
}
