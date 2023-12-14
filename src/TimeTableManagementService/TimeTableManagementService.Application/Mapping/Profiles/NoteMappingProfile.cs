using AutoMapper;
using TimetableManagement.Application.DTOs.Goal;

namespace HiringService.Application.Mapping.Profiles;

public class NoteMappingProfile : Profile
{
    public NoteMappingProfile()
    {
        CreateMap<AddNoteDTO, NoteEntity>();
        CreateMap<GetUpdateNoteDTO, NoteEntity>();
        CreateMap<NoteEntity, GetUpdateNoteDTO>();
    }
}
