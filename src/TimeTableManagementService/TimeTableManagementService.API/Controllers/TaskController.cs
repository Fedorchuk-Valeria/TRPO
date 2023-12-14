using Microsoft.AspNetCore.Mvc;
using TimetableManagement.Application.Abstractions.ServiceAbstractions;
using TimetableManagement.Application.DTOs;
using TimetableManagement.Application.DTOs.TaskDTOs;

namespace HiringService.API.Controllers;

[Route("tasks")]
[ApiController]
public class TaskController : ControllerBase
{
    protected readonly ITaskService _taskService;
    protected readonly IJWTService _JWTService;

    public TaskController(ITaskService taskService, IJWTService jWTService)
    {
        _taskService = taskService;
        _JWTService = jWTService;
    }

    [HttpPost]
    public async Task<IActionResult> GetAllByAndPeriodAsync([FromBody] PeriodDTO period)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var tasks = await _taskService.GetAllByUserIdAndPeriodAsync(
            period.StartDate,
            period.EndDate,
            (int)userId);

        return Ok(tasks);
    }

    [HttpPost("category/{categoryId:int}")]
    public async Task<IActionResult> GetAllByCategoryAndPeriodAsync(
        [FromRoute] int categoryId,
        [FromBody] PeriodDTO period)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var tasks = await _taskService.GetAllByUserCategoryAndPeriodAsync(
            period.StartDate,
            period.EndDate, 
            categoryId, 
            (int)userId);

        return Ok(tasks);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var task = await _taskService.GetByIdAndUserIdAsync(id, (int)userId);
        if (task is null) return BadRequest();

        return Ok(task);
    }

    [HttpPost("exact-time")]
    public async Task<IActionResult> AddExactTimeAsync([FromBody] AddExactTimeTaskDTO dto)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var task = await _taskService.AddExactTimeTaskAsync(dto, (int)userId);
        if (task is null) return BadRequest();

        return Ok(task);
    }

    [HttpPost("date-only")]
    public async Task<IActionResult> AddDateOnlyAsync([FromBody] AddDateOnlyTaskDTO dto)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var task = await _taskService.AddDateOnlyTaskAsync(dto, (int)userId);
        if (task is null) return BadRequest();

        return Ok(task);
    }

    [HttpPost("recurring")]
    public async Task<IActionResult> AddRecurringAsync([FromBody] AddRecurringTaskDTO dto)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var task = await _taskService.AddRecurringTaskAsync(dto, (int)userId);
        if (task is null) return BadRequest();

        return Ok(task);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var ok = await _taskService.RemoveByIdAndUserIdAsync(id, (int)userId);
        if (!ok) return BadRequest();

        return Ok();
    }
}
