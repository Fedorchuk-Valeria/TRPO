using AutoMapper;
using TimetableManagement.Application.DTOs.Goal;
using TimetableManagement.Domain.Entities;

namespace FinancialManagement.Application.Mapping.Profiles;

public class GoalMappingProfile : Profile
{
    public GoalMappingProfile()
    {
        CreateMap<GoalEntity, GetGoalDTO>();
        CreateMap<AddGoalDTO, GoalEntity>();
        CreateMap<UpdateGoalDTO, GoalEntity>();
    }
}
