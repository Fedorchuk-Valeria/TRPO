using AutoMapper;
using TimetableManagement.Application.DTOs.CategoryDTOs;
using TimetableManagement.Domain.Entities;

namespace FinancialManagement.Application.Mapping.Profiles;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<CategoryEntity, GetCategoryDTO>();
    }
}
