using Microsoft.EntityFrameworkCore;
using TimetableManagement.Application.Abstractions.RepositoryAbstractions;
using TimetableManagement.Domain.Entities;

namespace FinancialManagement.Infrastructure.Data.Repositories;

public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
{
    protected new readonly DataContext _context;

    public CategoryRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<CategoryEntity> AddAsync(CategoryEntity entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<List<CategoryEntity>> GetAllByUserIdAsync(int userId)
    {
        return await _context.Categories
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<CategoryEntity?> GetByIdAndUserIdAsync(int id, int userId)
    {
        return await _context.Categories
            .Where(x => x.Id == id)
            .Where(x => x.UserId == userId)
            .FirstOrDefaultAsync();
    }
}
