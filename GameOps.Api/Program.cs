using GameOps.Application.Abstractions;
using GameOps.Application.Games.CreateGame;
using GameOps.Application.Studios.CreateStudio;
using GameOps.Application.Studios.DeleteStudio;
using GameOps.Application.Studios.GetStudios;
using GameOps.Application.Studios.RenameStudio;
using GameOps.Infrastructure.Persistence;
using GameOps.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<GameOpsDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(5),
                errorNumbersToAdd: null);
        }));

builder.Services.AddScoped<IStudioRepository, StudioRepository>();
builder.Services.AddScoped<CreateStudioHandler>();
builder.Services.AddScoped<DeleteStudioHandler>();
builder.Services.AddScoped<GetStudiosHandler>();
builder.Services.AddScoped<UpdateStudioHandler>();
builder.Services.AddScoped<AddGameToStudioHandler>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<GameOpsDbContext>();
    var logger = services.GetRequiredService<ILogger<Program>>();

    var retries = 10;
    while (retries > 0)
    {
        try
        {
            logger.LogInformation("Applying migrations...");
            context.Database.Migrate();
            logger.LogInformation("✅ Migrations applied successfully");
            break;
        }
        catch (Exception ex)
        {
            retries--;
            logger.LogWarning(ex, "Database not ready. Retrying...");
            Thread.Sleep(5000);
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
