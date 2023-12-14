using AutoMapper;
using TimetableManagement.Application.Abstractions.RepositoryAbstractions;
using TimetableManagement.Application.Abstractions.ServiceAbstractions;
using TimetableManagement.Application.DTOs.Goal;
using TimetableManagement.Domain.Entities;

namespace TimetableManagement.Application.Services;

public class ImportantDateService : IImportantDateService
{
    protected readonly IImportantDateRepository _dateRepository;
    protected readonly IUserRepository _userRepository;
    protected readonly IMapper _mapper;

    public ImportantDateService(
        IImportantDateRepository dateRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _dateRepository = dateRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetImportantDateDTO?> AddAsync(AddImportantDateDTO dto, int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null) return null;

        var importantDateEntity = _mapper.Map<ImportantDateEntity>(dto);
        importantDateEntity.UserId = userId;

        _dateRepository.Add(importantDateEntity);
        await _dateRepository.SaveChangesAsync();

        return _mapper.Map<GetImportantDateDTO?>(importantDateEntity);
    }

    public async Task<List<GetImportantDateDTO>> GetAllByUserIdAsync(int userId)
    {
        var dates = await _dateRepository.GetAllByUserId(userId);

        return dates.Select(x => _mapper.Map<GetImportantDateDTO>(x)).ToList();
    }

    public async Task<bool> RemoveByIdAndUserIdAsync(int id, int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null) return false;

        var date = await _dateRepository.GetByIdAsync(id);
        if (date is null) return false;
        if (date.UserId != userId) return false;

        _dateRepository.Remove(date);
        await _dateRepository.SaveChangesAsync();

        return true;
    }

    public async Task<GetImportantDateDTO?> UpdateAsync(UpdateImportantDateDTO dto, int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null) return null;

        var date = await _dateRepository.GetByIdAsync(dto.Id);
        if (date is null) return null;
        if (date.UserId != userId) return null;

        date.Name = dto.Name;
        date.DateTime = dto.DateTime;

        _dateRepository.Update(date);
        await _dateRepository.SaveChangesAsync();

        return _mapper.Map<GetImportantDateDTO>(date);
    }
}
