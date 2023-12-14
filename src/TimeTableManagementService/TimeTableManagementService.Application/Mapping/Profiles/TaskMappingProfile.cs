using AutoMapper;
using TimetableManagement.Application.DTOs.TaskDTOs;
using TimetableManagement.Domain.Entities;

namespace HiringService.Application.Mapping.Profiles;

public class TaskMappingProfile : Profile
{
    public TaskMappingProfile()
    {
        CreateMap<TaskEntity, GetTaskDTO>();
    }
}
