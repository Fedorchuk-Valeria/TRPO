using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialManagement.Application.Authentication;

public static class AddAuthOptionsExtension
{
    public static IServiceCollection AddAuthOptions(
             this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthOptions>(configuration.GetSection("Auth"));

        return services;
    }
}
