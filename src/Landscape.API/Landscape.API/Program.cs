using Landscape.API.Extensions;
using Landscape.Application;
using Landscape.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(
    $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
    optional: false,
    reloadOnChange: true
).AddEnvironmentVariables();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();


if (app.Environment.IsStaging() || app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.ApplyMigrations();
    app.SeedData();
}

app.UseHttpsRedirection();

app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();