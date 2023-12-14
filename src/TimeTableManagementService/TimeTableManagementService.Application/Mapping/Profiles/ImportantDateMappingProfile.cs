using AutoMapper;
using TimetableManagement.Application.DTOs.Goal;
using TimetableManagement.Domain.Entities;

namespace FinancialManagement.Application.Mapping.Profiles;

public class ImportantDateMappingProfile : Profile
{
    public ImportantDateMappingProfile()
    {
        CreateMap<ImportantDateEntity, GetImportantDateDTO>();
        CreateMap<AddImportantDateDTO, ImportantDateEntity>();
        CreateMap<UpdateImportantDateDTO, ImportantDateEntity>();
    }
}
