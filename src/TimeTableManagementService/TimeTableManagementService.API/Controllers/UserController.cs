using Microsoft.AspNetCore.Mvc;
using TimetableManagement.Application.Abstractions.ServiceAbstractions;
using TimetableManagement.Application.DTOs.UserDTOs;

namespace HiringService.API.Controllers;

[Route("users")]
[ApiController]
public class UserController : ControllerBase
{
    protected readonly IUserService _userService;
    protected readonly IJWTService _JWTService;

    public UserController(IUserService userService, IJWTService jWTService)
    {
        _userService = userService;
        _JWTService = jWTService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] EmailPasswordDTO emailPassword)
    {
        var userId = await _userService.GetIdByEmailAndPasswordAsync(emailPassword);

        if (userId == null) return NotFound();

        var token = _JWTService.GetToken((int)userId);

        return Ok(token);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] AddUserDTO dto)
    {
        var userId = await _userService.AddAsync(dto);

        var token = _JWTService.GetToken(userId);

        return Ok(token);
    }

    [HttpGet]
    public async Task<IActionResult> GetPersonalInfo()
    {
        var userId = _JWTService.GetUserId(HttpContext.Request);
        if (userId is null) return Unauthorized();

        var user = await _userService.GetByIdAsync((int)userId);
        if (user is null) return NotFound();

        return Ok(user);
    }
}
