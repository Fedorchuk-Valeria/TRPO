using AutoMapper;
using TimetableManagement.Application.DTOs.Goal;
using TimetableManagement.Application.DTOs.ReminderDTOs;
using TimetableManagement.Domain.Entities;

namespace HiringService.Application.Mapping.Profiles;

public class ReminderMappingProfile : Profile
{
    public ReminderMappingProfile()
    {
        CreateMap<ReminderEntity, GetReminderDTO>();
        CreateMap<AddReminderDTO, ReminderEntity>();
    }
}
