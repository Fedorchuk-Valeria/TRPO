using AutoMapper;
using TimetableManagement.Application.Abstractions.RepositoryAbstractions;
using TimetableManagement.Application.Abstractions.ServiceAbstractions;
using TimetableManagement.Application.DTOs.CategoryDTOs;
using TimetableManagement.Domain.Entities;

namespace TimetableManagement.Application.Services;

public class CategoryService : ICategoryService
{
    protected readonly ICategoryRepository _categoryRepository;
    protected readonly IUserRepository _userRepository;
    protected readonly IMapper _mapper;

    public CategoryService(
        ICategoryRepository categoryRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetCategoryDTO?> AddAsync(string name, int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null) return null;

        var entity = new CategoryEntity() { Name = name, UserId = userId};

        return _mapper.Map<GetCategoryDTO>(await _categoryRepository.AddAsync(entity));
    }

    public async Task<GetCategoryDTO?> GetByIdAndUserIdAsync(int id, int userId)
    {
        return _mapper.Map<GetCategoryDTO>(await _categoryRepository.GetByIdAndUserIdAsync(id, userId));
    }

    public async Task<List<GetCategoryDTO>?> GetAllByUserIdAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null) return null;

        var entities = await _categoryRepository.GetAllByUserIdAsync(userId);

        return entities.Select(x => _mapper.Map<GetCategoryDTO>(x)).ToList();
    }

    public async Task<bool> RemoveByIdAndUserIdAsync(int id, int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null) return false;

        var category = await _categoryRepository.GetByIdAsync(id);
        if (category is null) return false;
        if (category.UserId != userId) return false;

        _categoryRepository.Remove(category);
        await _categoryRepository.SaveChangesAsync();

        return true;
    }
}
