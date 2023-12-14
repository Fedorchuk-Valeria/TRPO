using Microsoft.AspNetCore.Mvc;
using TimetableManagement.Application.Abstractions.ServiceAbstractions;
using TimetableManagement.Application.DTOs.Goal;

namespace HiringService.API.Controllers;

[Route("important-dates")]
[ApiController]
public class ImportantDateController : ControllerBase
{
    protected readonly IImportantDateService _dateService;
    protected readonly IJWTService _JWTService;

    public ImportantDateController(IImportantDateService dateService, IJWTService jWTService)
    {
        _dateService = dateService;
        _JWTService = jWTService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByUserIdAsync()
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var expenses = await _dateService.GetAllByUserIdAsync((int)userId);
        if (expenses is null) return BadRequest();

        return Ok(expenses);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddImportantDateDTO dto)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var income = await _dateService.AddAsync(dto, (int)userId);

        return Ok(income);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateImportantDateDTO dto)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var goal = await _dateService.UpdateAsync(dto, (int)userId);
        if (goal is null) return BadRequest();

        return Ok(goal);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] int id)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var ok = await _dateService.RemoveByIdAndUserIdAsync(id, (int)userId);
        if (!ok) return BadRequest();

        return Ok();
    }
}
