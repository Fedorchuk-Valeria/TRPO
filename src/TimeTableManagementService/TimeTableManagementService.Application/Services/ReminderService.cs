using AutoMapper;
using TimetableManagement.Application.Abstractions.RepositoryAbstractions;
using TimetableManagement.Application.Abstractions.ServiceAbstractions;
using TimetableManagement.Application.DTOs.ReminderDTOs;

namespace TimetableManagement.Application.Services;

internal class ReminderService : IReminderService
{
    public IReminderRepository _reminderRepository;
    public IUserRepository _userRepository;
    public IMapper _mapper;

    public ReminderService(
        IReminderRepository reminderRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _reminderRepository = reminderRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public Task<GetReminderDTO?> AddAsync(AddReminderDTO dto, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetReminderDTO>?> GetAllByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetReminderDTO>> RemoveAsync(int id, int userId)
    {
        throw new NotImplementedException();
    }
}
