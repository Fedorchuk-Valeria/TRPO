using TimetableManagement.Application.DTOs.TaskDTOs;

namespace TimetableManagement.Application.DTOs.OptimizationDTOs;

public class OptimizationResultDTO
{
    public DateOnly Date { get; set; }

    public Dictionary<TimeOnly, TimeOnly> SpareTimeIntervals { get; set; } = new(); //start, finish

    public List<GetDateOnlyTaskDTO> DateOnlyTasks {  get; set; } = new(); 
}
