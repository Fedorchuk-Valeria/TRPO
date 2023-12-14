using FinancialManagement.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using TimetableManagement.Application.Abstractions.RepositoryAbstractions;

namespace HiringService.Infrastructure.Data.Extensions;

public static class AddRepositoriesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IGoalRepository, GoalRepository>();
        services.AddScoped<IImportantDateRepository, ImportantDateRepository>();
        services.AddScoped<INoteRepository, NoteRepository>();
        services.AddScoped<IReminderRepository, ReminderRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
