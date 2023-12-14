using AutoMapper;
using TimetableManagement.Application.Abstractions.RepositoryAbstractions;
using TimetableManagement.Application.Abstractions.ServiceAbstractions;
using TimetableManagement.Application.DTOs.Goal;
using TimetableManagement.Domain.Entities;

namespace TimetableManagement.Application.Services;

public class GoalService : IGoalService
{
    protected readonly IGoalRepository _goalRepository;
    protected readonly IUserRepository _userRepository;
    protected readonly IMapper _mapper;

    public GoalService(
        IGoalRepository goalRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _goalRepository = goalRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetGoalDTO?> AddAsync(AddGoalDTO dto, int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null) return null;

        var goalEntity = _mapper.Map<GoalEntity>(dto);
        goalEntity.UserId = userId;

        _goalRepository.Add(goalEntity);
        await _goalRepository.SaveChangesAsync();

        return _mapper.Map<GetGoalDTO>(goalEntity);
    }

    public async Task<List<GetGoalDTO>?> GetAllByUserIdAsync(int userId)
    {
         var user = await _userRepository.GetByIdAsync(userId);
         if (user is null) return null;

        var goals = await _goalRepository.GetAllByUserId(userId);

        return goals.Select(x => _mapper.Map<GetGoalDTO>(x)).ToList();
    }

    public async Task<bool> RemoveByIdAndUserIdAsync(int id, int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null) return false;

        var goal = await _goalRepository.GetByIdAsync(id);
        if (goal is null) return false;
        if (goal.UserId != userId) return false;

        _goalRepository.Remove(goal);
        await _goalRepository.SaveChangesAsync();

        return true;
    }

    public async Task<GetGoalDTO?> UpdateAsync(UpdateGoalDTO dto, int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null) return null;

        var goal = await _goalRepository.GetByIdAsync(dto.Id);
        if (goal is null) return null;
        if (goal.UserId != userId) return null;

        goal.GoalTitle = dto.GoalTitle;
        goal.FinishDate = dto.FinishDate;

        _goalRepository.Update(goal);
        await _goalRepository.SaveChangesAsync();

        return _mapper.Map<GetGoalDTO>(goal);
    }
}
