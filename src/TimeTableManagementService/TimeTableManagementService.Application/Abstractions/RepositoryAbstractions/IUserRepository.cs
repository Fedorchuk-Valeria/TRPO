using TimetableManagement.Domain.Entities;

namespace TimetableManagement.Application.Abstractions.RepositoryAbstractions;

public interface IUserRepository : IGenericRepository<UserEntity>
{
    Task<int?> GetIdByEmailAndPasswordAsync(string email, string password);
}
