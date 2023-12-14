using AutoMapper;
using TimetableManagement.Application.Abstractions.RepositoryAbstractions;
using TimetableManagement.Application.Abstractions.ServiceAbstractions;
using TimetableManagement.Application.DTOs.Goal;

namespace TimetableManagement.Application.Services;

public class NoteService : INoteService
{
    protected readonly INoteRepository _noteRepository;
    protected readonly ICategoryRepository _categoryRepository;
    protected readonly IUserRepository _userRepository;
    protected readonly IMapper _mapper;

    public NoteService(
        INoteRepository noteRepository,
        ICategoryRepository categoryRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _noteRepository = noteRepository;
        _categoryRepository = categoryRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetUpdateNoteDTO?> AddAsync(AddNoteDTO dto, int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null) return null;

        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
        if (category is null) return null;
        if (category.UserId != userId) return null;

        var noteEntity = _mapper.Map<NoteEntity>(dto);

        _noteRepository.Add(noteEntity);
        await _noteRepository.SaveChangesAsync();

        return _mapper.Map<GetUpdateNoteDTO>(noteEntity);
    }

    public async Task<List<GetUpdateNoteDTO>> GetAllByUserCategoryAsync(int categoryId, int userId)
    {
        var entities = await _noteRepository.GetAllByUserCategoryAsync(categoryId, userId);

        return entities.Select(x => _mapper.Map<GetUpdateNoteDTO>(x)).ToList();
    }

    public async Task<List<GetUpdateNoteDTO>> GetAllByUserIdAsync(int userId)
    {
        var entities = await _noteRepository.GetAllByUserIdAsync(userId);

        return entities.Select(x => _mapper.Map<GetUpdateNoteDTO>(x)).ToList();
    }

    public async Task<GetUpdateNoteDTO?> GetByIdAndUserIdAsync(int id, int userId)
    {
        return _mapper.Map<GetUpdateNoteDTO>(await _noteRepository.GetByIdAndUserIdAsync(id, userId));
    }

    public async Task<bool> RemoveByIdAndUserIdAsync(int id, int userId)
    {
        var note = await _noteRepository.GetByIdAndUserIdAsync(id, userId);
        if (note is null) return false;

        _noteRepository.Remove(note);
        await _noteRepository.SaveChangesAsync();

        return true;
    }
}
