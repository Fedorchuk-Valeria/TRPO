using Microsoft.EntityFrameworkCore;
using TimetableManagement.Application.Abstractions.RepositoryAbstractions;
using TimetableManagement.Domain.Entities;

namespace FinancialManagement.Infrastructure.Data.Repositories;

public class UserRepository : GenericRepository<UserEntity>, IUserRepository
{
    protected new readonly DataContext _context;

    public UserRepository(DataContext context) : base(context) 
    {
        _context = context;
    }

    public async Task<int?> GetIdByEmailAndPasswordAsync(string email, string password)
    {
        return await _context.Users
            .Where(x => x.Email == email && x.Password == password)
            .Select(x => (int?)x.Id)
            .FirstOrDefaultAsync();
    }
}
