using Microsoft.EntityFrameworkCore;
using TimetableManagement.Application.Abstractions.RepositoryAbstractions;
using TimetableManagement.Domain.Entities;

namespace FinancialManagement.Infrastructure.Data.Repositories;

public class ImportantDateRepository : GenericRepository<ImportantDateEntity>, IImportantDateRepository
{
    protected new readonly DataContext _context;

    public ImportantDateRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<ImportantDateEntity>> GetAllByUserId(int userId)
    {
        return await _context.ImportantDates.Where(x => x.UserId == userId).ToListAsync();
    }
}
