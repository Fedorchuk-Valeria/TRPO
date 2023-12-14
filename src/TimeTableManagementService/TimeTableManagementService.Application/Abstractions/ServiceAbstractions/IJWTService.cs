using Microsoft.AspNetCore.Http;

namespace TimetableManagement.Application.Abstractions.ServiceAbstractions;

public interface IJWTService
{
    public int? GetUserId(HttpRequest request);

    public string GetToken(int userId);

}
