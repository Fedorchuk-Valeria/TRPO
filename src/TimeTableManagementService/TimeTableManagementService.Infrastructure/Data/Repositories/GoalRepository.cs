using Microsoft.EntityFrameworkCore;
using TimetableManagement.Application.Abstractions.RepositoryAbstractions;
using TimetableManagement.Application.DTOs.Goal;
using TimetableManagement.Domain.Entities;

namespace FinancialManagement.Infrastructure.Data.Repositories;

public class GoalRepository : GenericRepository<GoalEntity>, IGoalRepository
{
    protected new readonly DataContext _context;

    public GoalRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<GoalEntity>> GetAllByUserId(int userId)
    {
        return await _context.Goals.Where(x => x.UserId == userId).ToListAsync();
    }
}
