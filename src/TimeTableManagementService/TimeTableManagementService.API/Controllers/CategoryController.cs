using Microsoft.AspNetCore.Mvc;
using TimetableManagement.Application.Abstractions.ServiceAbstractions;

namespace HiringService.API.Controllers;

[Route("categories")]
[ApiController]
public class CategoryController : ControllerBase
{
    protected readonly ICategoryService _categoryService;
    protected readonly IJWTService _JWTService;

    public CategoryController(ICategoryService categoryService, IJWTService jWTService)
    {
        _categoryService = categoryService;
        _JWTService = jWTService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByUserIdAsync()
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var debts = await _categoryService.GetAllByUserIdAsync((int)userId);
        if (debts is null) return BadRequest();

        return Ok(debts);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAndUserIdAsync([FromRoute] int id)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var debt = await _categoryService.GetByIdAndUserIdAsync(id, (int)userId);
        if (debt is null) return BadRequest();

        return Ok(debt);
    }

    [HttpPost("{name}")]
    public async Task<IActionResult> AddAsync([FromRoute] string name)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var debt = await _categoryService.AddAsync(name, (int)userId);
        if (debt is null) return BadRequest();

        return Ok(debt);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RemoveByIdAndUserIdAsync([FromRoute] int id)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var ok = await _categoryService.RemoveByIdAndUserIdAsync(id, (int)userId);
        if (!ok) return BadRequest();

        return Ok();
    }
}
