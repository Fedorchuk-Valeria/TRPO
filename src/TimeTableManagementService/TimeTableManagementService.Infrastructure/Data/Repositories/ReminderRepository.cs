using TimetableManagement.Application.Abstractions.RepositoryAbstractions;
using TimetableManagement.Domain.Entities;

namespace FinancialManagement.Infrastructure.Data.Repositories;

internal class ReminderRepository : GenericRepository<ReminderEntity>, IReminderRepository
{
    protected new readonly DataContext _context;

    public ReminderRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public Task<List<int>> GetIdsByUserId(int userId)
    {
        throw new NotImplementedException();
    }

    //public async Task<List<int>> GetIdsByUserId(int userId)
    //{
    //    return await _context.IncomeSources
    //        .Where(x => x.UserId == userId)
    //        .Select(x => x.Id)
    //        .ToListAsync();
    //}
}
