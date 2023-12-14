using Microsoft.EntityFrameworkCore;
using TimetableManagement.Application.Abstractions.RepositoryAbstractions;
using TimetableManagement.Domain.Entities;

namespace FinancialManagement.Infrastructure.Data.Repositories;

public class NoteRepository : GenericRepository<NoteEntity>, INoteRepository
{
    protected new readonly DataContext _context;

    public NoteRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<NoteEntity>> GetAllByUserCategoryAsync(int categoryId, int userId)
    {
        return await _context.Notes
            .Where(x => x.Category.UserId == userId)
            .Where(x => x.CategoryId == categoryId)
            .ToListAsync();
    }

    public async Task<List<NoteEntity>> GetAllByUserIdAsync(int userId)
    {
        return await _context.Notes
            .Where(x => x.Category.UserId == userId)
            .ToListAsync();
    }

    public async Task<NoteEntity?> GetByIdAndUserIdAsync(int id, int userId)
    {
        return await _context.Notes
            .Where(x => x.Id == id)
            .Where(x => x.Category.UserId == userId)
            .FirstOrDefaultAsync();
    }
}
