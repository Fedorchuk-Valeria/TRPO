using TimetableManagement.Application.DTOs.ReminderDTOs;

namespace TimetableManagement.Application.Abstractions.ServiceAbstractions;

public interface IReminderService
{
    Task<List<GetReminderDTO>?> GetAllByUserIdAsync(int userId);

    public Task<GetReminderDTO?> AddAsync(AddReminderDTO dto, int userId);

    public Task<List<GetReminderDTO>> RemoveAsync(int id, int userId);
}
