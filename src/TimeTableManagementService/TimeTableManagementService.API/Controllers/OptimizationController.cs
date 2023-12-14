using Microsoft.AspNetCore.Mvc;
using TimetableManagement.Application.Abstractions.ServiceAbstractions;
using TimetableManagement.Application.DTOs.OptimizationDTOs;

namespace HiringService.API.Controllers;

[Route("optimization")]
[ApiController]
public class OptimizationController : ControllerBase
{
    protected readonly IOptimizationService _optimizationService;
    protected readonly IJWTService _JWTService;

    public OptimizationController(IOptimizationService optimizationService, IJWTService jWTService)
    {
        _optimizationService = optimizationService;
        _JWTService = jWTService;
    }

    [HttpPost]
    public async Task<IActionResult> GetOptimizationAsync([FromBody] OptimizationDTO dto)
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var optimizationResults = await _optimizationService.FindTimeforATask(dto, (int)userId);

        return Ok(optimizationResults);
    }
}
