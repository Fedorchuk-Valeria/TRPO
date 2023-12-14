using TimetableManagement.Application.Abstractions.RepositoryAbstractions;
using TimetableManagement.Application.DTOs.UserDTOs;

namespace TimetableManagement.Application.Abstractions.ServiceAbstractions;

public interface IUserService
{
    Task<int?> GetIdByEmailAndPasswordAsync(EmailPasswordDTO emailPassword);

    Task<GetUserDTO> GetByIdAsync(int id);

    Task<int> AddAsync(AddUserDTO dto);
}
