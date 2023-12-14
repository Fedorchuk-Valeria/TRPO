using FinancialManagement.Application.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TimetableManagement.Application.Abstractions.ServiceAbstractions;

namespace TimetableManagement.Application.Services;

public class JWTService : IJWTService
{
    private readonly AuthOptions _authOptions;

    public JWTService(IOptions<AuthOptions> options)
    {
        _authOptions = options.Value;
    }

    public int? GetUserId(HttpRequest request)
    {
        var token = request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

        var stringId = jwtToken.Claims
            .FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.NameId)?.Value;

        if (int.TryParse(stringId, out int id)) return id;

        return null;
    }

    public string GetToken(int userId)
    {
        var claims = new List<Claim> {
            new Claim(JwtRegisteredClaimNames.NameId, userId.ToString())
        };

        var jwt = new JwtSecurityToken(
            _authOptions.Issuer,
            _authOptions.Audience,
            claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(_authOptions.TokenLifeTime)),
            signingCredentials: new SigningCredentials(
                _authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
