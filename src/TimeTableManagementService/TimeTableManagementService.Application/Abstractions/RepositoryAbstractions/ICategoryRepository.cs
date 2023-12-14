using TimetableManagement.Domain.Entities;

namespace TimetableManagement.Application.Abstractions.RepositoryAbstractions;

public interface ICategoryRepository : IGenericRepository<CategoryEntity>
{
    Task<List<CategoryEntity>> GetAllByUserIdAsync(int userId);

    Task<CategoryEntity?> GetByIdAndUserIdAsync(int id, int userId);

    Task<CategoryEntity> AddAsync(CategoryEntity entity);
}
