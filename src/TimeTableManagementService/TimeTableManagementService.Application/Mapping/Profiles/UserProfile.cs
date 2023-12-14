using AutoMapper;
using TimetableManagement.Application.DTOs.UserDTOs;
using TimetableManagement.Domain.Entities;

namespace HiringService.Application.Mapping.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserEntity, GetUserDTO>();
        CreateMap<AddUserDTO, UserEntity>();
    }
}
