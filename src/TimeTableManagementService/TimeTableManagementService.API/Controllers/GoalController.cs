using Microsoft.AspNetCore.Mvc;
using TimetableManagement.Application.Abstractions.ServiceAbstractions;
using TimetableManagement.Application.DTOs.Goal;

namespace HiringService.API.Controllers;

[Route("goals")]
[ApiController]
public class GoalController : ControllerBase
{
    protected readonly IGoalService _goalService;
    protected readonly IJWTService _JWTService;

    public GoalController(IGoalService goalService, IJWTService jWTService)
    {
        _goalService = goalService;
        _JWTService = jWTService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByUserIdAsync()
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var goals = await _goalService.GetAllByUserIdAsync((int)userId);

        return Ok(goals);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddGoalDTO dto)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var goal = await _goalService.AddAsync(dto, (int)userId);

        return Ok(goal);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateGoalDTO dto)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var goal = await _goalService.UpdateAsync(dto, (int)userId);

        return Ok(goal);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] int id)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        await _goalService.RemoveByIdAndUserIdAsync(id, (int)userId);

        return Ok();
    }
}
