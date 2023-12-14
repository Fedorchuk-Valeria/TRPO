//using FinancialManagement.Application.DTOs;
//using Microsoft.AspNetCore.Mvc;
//using TimetableManagement.Application.Abstractions.ServiceAbstractions;

//namespace HiringService.API.Controllers;

//[Route("reminders")]
//[ApiController]
//public class ReminderController : ControllerBase
//{
//    protected readonly IReminderService _sourceService;
//    protected readonly IJWTService _JWTService;

//    public ReminderController(IReminderService sourceService, IJWTService jWTService)
//    {
//        _sourceService = sourceService;
//        _JWTService = jWTService;
//    }

//    [HttpGet]
//    public async Task<IActionResult> GetAllByUserIdAsync()
//    {
//        var userId = _JWTService.GetUserId(HttpContext.Request);
//        if (userId is null) return Unauthorized();

//        var categories = await _sourceService.GetAllByUserIdAsync((int)userId);

//        return Ok(categories);
//    }

//    [HttpGet("{sourceId:int}")]
//    public async Task<IActionResult> GetByIdAsync([FromRoute] int sourceId)
//    {
//        var userId = _JWTService.GetUserId(HttpContext.Request);
//        if (userId is null) return Unauthorized();

//        var source = await _sourceService.GetByIdAsync(sourceId, (int)userId);

//        return Ok(source);
//    }

//    [HttpPost("{name}")]
//    public async Task<IActionResult> AddAsync([FromRoute] string name)
//    {
//        var userId = _JWTService.GetUserId(HttpContext.Request);
//        if (userId is null) return Unauthorized();

//        var source = await _sourceService.AddAsync(name, (int)userId);

//        return Ok(source);
//    }

//    [HttpPut("{id:int}/{newName}")]
//    public async Task<IActionResult> UpdateNameAsync([FromRoute] int id, [FromRoute] string newName)
//    {
//        var userId = _JWTService.GetUserId(HttpContext.Request);
//        if (userId is null) return Unauthorized();

//        var source = await _sourceService.UpdateNameAsync(id, newName, (int)userId);

//        return Ok(source);
//    }

//    [HttpDelete("{id:int}")]
//    public async Task<IActionResult> RemoveAsync([FromRoute] int id)
//    {
//        var userId = _JWTService.GetUserId(HttpContext.Request);
//        if (userId is null) return Unauthorized();

//        await _sourceService.RemoveAsync(id, (int)userId);

//        return NoContent();
//    }
//}
