using Microsoft.Extensions.DependencyInjection;
using TimetableManagement.Application.Abstractions.ServiceAbstractions;

namespace TimetableManagement.Application.Services;

public static class AddServicesExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IGoalService, GoalService>();
        services.AddScoped<IImportantDateService, ImportantDateService>();
        services.AddScoped<INoteService, NoteService>();
        services.AddScoped<IReminderService, ReminderService>();
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<IOptimizationService, OptimizationService>();

        services.AddSingleton<IJWTService, JWTService>();

        return services;
    }
}