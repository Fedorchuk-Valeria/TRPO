using Microsoft.AspNetCore.Mvc;
using TimetableManagement.Application.Abstractions.ServiceAbstractions;
using TimetableManagement.Application.DTOs;
using TimetableManagement.Application.DTOs.Goal;

namespace HiringService.API.Controllers;

[Route("notes")]
[ApiController]
public class NoteController : ControllerBase
{
    protected readonly INoteService _noteService;
    protected readonly IJWTService _JWTService;

    public NoteController(INoteService noteService, IJWTService jWTService)
    {
        _noteService = noteService;
        _JWTService = jWTService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByUserIdAsync()
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var tasks = await _noteService.GetAllByUserIdAsync((int)userId);

        return Ok(tasks);
    }

    [HttpGet("category/{categoryId:int}")]
    public async Task<IActionResult> GetAllByCategoryAndPeriodAsync([FromRoute] int categoryId)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var tasks = await _noteService.GetAllByUserCategoryAsync(categoryId, (int)userId);

        return Ok(tasks);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var task = await _noteService.GetByIdAndUserIdAsync(id, (int)userId);
        if (task is null) return BadRequest();

        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> AddExactTimeAsync([FromBody] AddNoteDTO dto)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var task = await _noteService.AddAsync(dto, (int)userId);
        if (task is null) return BadRequest();

        return Ok(task);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RemoveByIdAndUserIdAsync([FromRoute] int id)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var ok = await _noteService.RemoveByIdAndUserIdAsync(id, (int)userId);
        if (!ok) return BadRequest();

        return Ok();
    }
}
