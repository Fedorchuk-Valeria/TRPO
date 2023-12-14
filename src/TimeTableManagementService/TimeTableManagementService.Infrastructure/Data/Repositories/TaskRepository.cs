using Microsoft.EntityFrameworkCore;
using TimetableManagement.Application.Abstractions.RepositoryAbstractions;
using TimetableManagement.Domain.Entities;
using TimetableManagement.Domain.Enumerations;

namespace FinancialManagement.Infrastructure.Data.Repositories;

public class TaskRepository : GenericRepository<TaskEntity>, ITaskRepository
{
    protected new readonly DataContext _context;

    public TaskRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<TaskEntity> AddAsync(TaskEntity entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<List<TaskEntity>> GetAllByUserCategoryAndPeriodAsync(DateTime startdate, DateTime endDate, int categoryId, int userId)
    {
        var notRecurringTasks = await _context.Tasks
            .Where(x => x.TaskType != TaskType.Recurring)
            .Where(x => x.Category.UserId == userId)
            .Where(x => x.CategoryId == categoryId)
            .Where(x => x.StartDate > startdate)
            .Where(x => x.StartDate.AddDays(x.Duration.Days) < endDate)
            .ToListAsync();

        var recurringTasks = await _context.Tasks
            .Where(x => x.TaskType == TaskType.Recurring)
            .ToListAsync();

        notRecurringTasks.AddRange(recurringTasks);

        return notRecurringTasks;
    }

    public async Task<List<TaskEntity>> GetAllByUserIdAndPeriodAsync(DateTime startdate, DateTime endDate, int userId)
    {
        var notRecurringTasks = await _context.Tasks
            .Where(x => x.TaskType != TaskType.Recurring)
            .Where(x => x.Category.UserId == userId)
            .Where(x => x.StartDate > startdate)
            .Where(x => x.StartDate.AddDays(x.Duration.Days) < endDate)
            .ToListAsync();

        var recurringTasks = await _context.Tasks
            .Where(x => x.TaskType == TaskType.Recurring)
            .ToListAsync();

        notRecurringTasks.AddRange(recurringTasks);

        return notRecurringTasks;
    }

    public async Task<TaskEntity?> GetByIdAndUserIdAsync(int id, int userId)
    {
        return await _context.Tasks
                    .Where(x => x.Id == id)
                    .Where(x => x.Category.UserId == userId)
                    .FirstOrDefaultAsync();
    }
}
