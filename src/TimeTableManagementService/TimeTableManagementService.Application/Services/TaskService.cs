using AutoMapper;
using TimetableManagement.Application.Abstractions.RepositoryAbstractions;
using TimetableManagement.Application.Abstractions.ServiceAbstractions;
using TimetableManagement.Application.DTOs.TaskDTOs;
using TimetableManagement.Domain.Entities;
using TimetableManagement.Domain.Enumerations;

namespace TimetableManagement.Application.Services;

public class TaskService : ITaskService
{
    protected readonly ITaskRepository _taskRepository;
    protected readonly ICategoryRepository _categoryRepository;
    protected readonly IUserRepository _userRepository;
    protected readonly IMapper _mapper;

    public TaskService(
        ITaskRepository taskRepository,
        ICategoryRepository categoryRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _taskRepository = taskRepository;
        _categoryRepository = categoryRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetTaskDTO?> AddDateOnlyTaskAsync(AddDateOnlyTaskDTO dto, int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null) return null;

        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
        if (category is null) return null;
        if (category.UserId != userId) return null;

        var taskEntity = new TaskEntity()
        {
            TaskType = TaskType.DateOnly,

            Name = dto.Name,

            StartDate = dto.StartDate,

            Duration = dto.Duration,

            CategoryId = dto.CategoryId,
        };

        return _mapper.Map<GetTaskDTO>(await _taskRepository.AddAsync(taskEntity));
    }

    public async Task<GetTaskDTO?> AddExactTimeTaskAsync(AddExactTimeTaskDTO dto, int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null) return null;

        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
        if (category is null) return null;
        if (category.UserId != userId) return null;

        var newTaskEntity = new TaskEntity()
        {
            TaskType = TaskType.ExactTime,

            Name = dto.Name,

            StartDate = dto.StartDateTime,

            Duration = dto.EndDateTime - dto.StartDateTime,

            CategoryId = dto.CategoryId,
        };

        var tasks = await GetAllByUserIdAndPeriodAsync(dto.StartDateTime.AddDays(-3), dto.EndDateTime.AddDays(3), userId);

        //test if time is busy
        foreach (var task in tasks)
        {
            if (task.StartDate >= newTaskEntity.StartDate &&
                task.StartDate <= newTaskEntity.StartDate + newTaskEntity.Duration)
            {
                return null;
            }
            if (task.StartDate + task.Duration <= newTaskEntity.StartDate + newTaskEntity.Duration &&
                task.StartDate + task.Duration >= newTaskEntity.StartDate)
            {
                return null;
            }
        }

        return _mapper.Map<GetTaskDTO>(await _taskRepository.AddAsync(newTaskEntity));
    }

    public async Task<GetTaskDTO?> AddRecurringTaskAsync(AddRecurringTaskDTO dto, int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null) return null;

        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
        if (category is null) return null;
        if (category.UserId != userId) return null;

        var newTaskEntity = new TaskEntity()
        {
            TaskType = TaskType.Recurring,

            Name = dto.Name,

            StartDate = dto.StartDateTime,

            Duration = dto.EndDateTime - dto.StartDateTime,

            RepeatPeriod = dto.RepeatPeriod,

            CategoryId = dto.CategoryId,
        };

        var tasks = await GetAllByUserIdAndPeriodAsync(
            dto.StartDateTime.AddDays(-3),
            dto.EndDateTime.AddDays(dto.RepeatPeriod*10), userId);

        //test if time for all recurring task dublicates is not busy
        var date = newTaskEntity.StartDate;

        while (date < dto.EndDateTime.AddDays(dto.RepeatPeriod * 10))
        {
            foreach (var task in tasks)
            {
                if (task.StartDate >= date &&
                    task.StartDate <= date + newTaskEntity.Duration)
                {
                    return null;
                }
                if (task.StartDate + task.Duration <= date + newTaskEntity.Duration &&
                    task.StartDate + task.Duration >= date)
                {
                    return null;
                }
            }

            date = date.AddDays(newTaskEntity.RepeatPeriod);
        }
        
        return _mapper.Map<GetTaskDTO>(await _taskRepository.AddAsync(newTaskEntity));
    }

    public async Task<List<GetTaskDTO>> GetAllByUserCategoryAndPeriodAsync(DateTime startdate, DateTime endDate, int categoryId, int userId)
    {
        var taskEntities = await _taskRepository.GetAllByUserCategoryAndPeriodAsync(startdate, endDate, categoryId, userId);

        var notRecurringTasks = taskEntities.Where(x => x.TaskType != TaskType.Recurring).ToList();

        var recurringTasks = taskEntities.Where(x => x.TaskType == TaskType.Recurring).ToList();
        foreach (var task in recurringTasks)
        {
            var date = task.StartDate.AddDays(task.RepeatPeriod);

            while (date < endDate)
            {
                if (date < startdate) continue;

                var newTask = new TaskEntity 
                {
                    Name = task.Name,
                    TaskType = TaskType.Recurring,
                    StartDate = date,
                    Duration = task.Duration,
                    RepeatPeriod = task.RepeatPeriod,
                    CategoryId = task.CategoryId,
                };

                notRecurringTasks.Add(newTask);

                date = date.AddDays(task.RepeatPeriod);
            }
        }

        return notRecurringTasks.Select(x => _mapper.Map<GetTaskDTO>(x)).ToList();
    }

    public async Task<List<GetTaskDTO>> GetAllByUserIdAndPeriodAsync(DateTime startdate, DateTime endDate, int userId)
    {
        var taskEntities = await _taskRepository.GetAllByUserIdAndPeriodAsync(startdate, endDate, userId);

        var notRecurringTasks = taskEntities.Where(x => x.TaskType != TaskType.Recurring).ToList();

        var recurringTasks = taskEntities.Where(x => x.TaskType == TaskType.Recurring).ToList();
        foreach (var task in recurringTasks)
        {
            var date = task.StartDate.AddDays(task.RepeatPeriod);

            while (date < endDate)
            {
                if (date < startdate)
                {
                    date = date.AddDays(task.RepeatPeriod);
                    continue;
                }

                var newTask = new TaskEntity
                {
                    Id = task.Id,
                    Name = task.Name,
                    TaskType = TaskType.Recurring,
                    StartDate = date,
                    Duration = task.Duration,
                    RepeatPeriod = task.RepeatPeriod,
                    CategoryId = task.CategoryId,
                };

                notRecurringTasks.Add(newTask);

                date = date.AddDays(task.RepeatPeriod);
            }
        }

        return notRecurringTasks.Select(x => _mapper.Map<GetTaskDTO>(x)).ToList();
    }

    public async Task<GetTaskDTO?> GetByIdAndUserIdAsync(int id, int userId)
    {
        return _mapper.Map<GetTaskDTO>(await _taskRepository.GetByIdAndUserIdAsync(id, userId));
    }

    public async Task<bool> RemoveByIdAndUserIdAsync(int id, int userId)
    {
        var task = await _taskRepository.GetByIdAndUserIdAsync(id, userId);
        if (task is null) return false;

        _taskRepository.Remove(task);
        await _taskRepository.SaveChangesAsync();

        return true;
    }
}
