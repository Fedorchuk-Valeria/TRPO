using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialManagement.Infrastructure.Data.Extensions;

public static class AddDatabaseConfigurationExtension
{
    public static IServiceCollection AddDatabaseConfiguration(
             this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(
            o => o.UseNpgsql(
                configuration.GetConnectionString("TimetableManagementDB"),
                b => b.MigrationsAssembly(configuration.GetSection("MigrationsAssembly").Get<string>())
            )
            .EnableSensitiveDataLogging()
        );

        return services;
    }
}
