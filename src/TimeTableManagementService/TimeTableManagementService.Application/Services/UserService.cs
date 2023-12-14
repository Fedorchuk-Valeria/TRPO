using AutoMapper;
using TimetableManagement.Application.Abstractions.RepositoryAbstractions;
using TimetableManagement.Application.Abstractions.ServiceAbstractions;
using TimetableManagement.Application.DTOs.UserDTOs;
using TimetableManagement.Domain.Entities;

namespace TimetableManagement.Application.Services;

public class UserService : IUserService
{
    protected readonly IUserRepository _userRepository;
    protected readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<int> AddAsync(AddUserDTO dto)
    {
        var user = _mapper.Map<UserEntity>(dto);

        _userRepository.Add(user);
        await _userRepository.SaveChangesAsync();

        return user.Id;
    }

    public async Task<int?> GetIdByEmailAndPasswordAsync(EmailPasswordDTO emailPassword)
    {
        var userId = await _userRepository.GetIdByEmailAndPasswordAsync(emailPassword.Email, emailPassword.Password);

        return userId;
    }

    public async Task<GetUserDTO> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        return _mapper.Map<GetUserDTO>(user);
    }
}
