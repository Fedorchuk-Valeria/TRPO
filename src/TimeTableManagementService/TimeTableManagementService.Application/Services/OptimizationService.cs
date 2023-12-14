using TimetableManagement.Application.Abstractions.ServiceAbstractions;
using TimetableManagement.Application.DTOs.OptimizationDTOs;
using TimetableManagement.Domain.Enumerations;

namespace TimetableManagement.Application.Services;

internal class OptimizationService : IOptimizationService
{
    private readonly ITaskService _taskService;

    public OptimizationService(
        ITaskService taskService)
    {
        _taskService = taskService;;
    }

    public async Task<List<OptimizationResultDTO>> FindTimeforATask(OptimizationDTO dto, int userId)
    {
        var tasks = await _taskService.GetAllByUserIdAndPeriodAsync(dto.StartDate, dto.EndDate, userId);
        tasks = tasks.Where(x => x.TaskType != TaskType.DateOnly).OrderBy(x => x.StartDate).ToList();

        var optimizationResults = new List<OptimizationResultDTO>();

        var date = dto.StartDate;
        while (date <= dto.EndDate)
        {
            optimizationResults.Add(new OptimizationResultDTO() {
                Date = DateOnly.FromDateTime(date),
                //DateOnlyTasks = await _taskService.GetDateOnlyTasksByDate(DateOnly.FromDateTime(date)),
                SpareTimeIntervals = new Dictionary<TimeOnly, TimeOnly>() {
                    { new TimeOnly(8, 0), new TimeOnly(20, 0) } 
                },
            });

            date = date.AddDays(1);
        }

        //удалить интервалы меньше Duration
        foreach (var optimizationResult in optimizationResults)
        {
            var intervalKeys = optimizationResult.SpareTimeIntervals.Keys;

            foreach (var intervalKey in intervalKeys)
            {
                foreach (var task in tasks)
                {
                    // task is inside of interval (divide the interval into 2 parts)
                    if (TimeOnly.FromDateTime(task.StartDate) >= intervalKey &&
                        TimeOnly.FromDateTime(task.StartDate + task.Duration) <= optimizationResult.SpareTimeIntervals[intervalKey])
                    {
                        // 2 interval
                        optimizationResult.SpareTimeIntervals[TimeOnly.FromDateTime(task.StartDate + task.Duration)]
                            = optimizationResult.SpareTimeIntervals[intervalKey];
                        // 1 interval
                        optimizationResult.SpareTimeIntervals[intervalKey] = TimeOnly.FromDateTime(task.StartDate);

                        continue;
                    }
                    // interval is inside of task (delete interval)
                    if (TimeOnly.FromDateTime(task.StartDate) <= intervalKey &&
                        TimeOnly.FromDateTime(task.StartDate + task.Duration) >= optimizationResult.SpareTimeIntervals[intervalKey])
                    {
                        optimizationResult.SpareTimeIntervals.Remove(intervalKey);
                        continue;
                    }
                    //task hits the end of the interval (cut off the end of the interval)
                    if (TimeOnly.FromDateTime(task.StartDate) >= intervalKey &&
                        TimeOnly.FromDateTime(task.StartDate) <= optimizationResult.SpareTimeIntervals[intervalKey])
                    {
                        optimizationResult.SpareTimeIntervals[intervalKey] = TimeOnly.FromDateTime(task.StartDate);
                        continue;
                    }
                    //task hits the start of the interval (cut off the start of the interval)
                    if (TimeOnly.FromDateTime(task.StartDate + task.Duration) <= optimizationResult.SpareTimeIntervals[intervalKey] &&
                        TimeOnly.FromDateTime(task.StartDate + task.Duration) >= intervalKey)
                    {
                        optimizationResult.SpareTimeIntervals[TimeOnly.FromDateTime(task.StartDate + task.Duration)]
                            = optimizationResult.SpareTimeIntervals[intervalKey];

                        optimizationResult.SpareTimeIntervals.Remove(intervalKey);
                        continue;
                    }
                }
            }
        }
        
        return optimizationResults;
    }
}
