using FinancialManagement.Application.Authentication;
using FinancialManagement.Infrastructure.Data.Extensions;
using HiringService.Application.Mapping;
using HiringService.Infrastructure.Data;
using HiringService.Infrastructure.Data.Extensions;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using TimetableManagement.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddRepositories();

builder.Services.AddServices();

builder.Services.AddMapping();

builder.Services.AddControllers();

//builder.Services.AddKafkaBGServices();

builder.Services.AddAuthOptions(builder.Configuration);
builder.Services.AddAuthenticationAndAuthorization(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(SwaggerAuthConfiguration.Configure);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //using var scope = app.Services.CreateScope();
    //var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    //await TestingDataContainer.AddTestingData(context);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
