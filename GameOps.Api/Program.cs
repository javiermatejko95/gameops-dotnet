using GameOps.Application.Abstractions;
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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<GameOpsDbContext>(options =>
    options.UseSqlite("Data Source=gameops.db"));

builder.Services.AddScoped<IStudioRepository, StudioRepository>();
builder.Services.AddScoped<CreateStudioHandler>();
builder.Services.AddScoped<CreateStudioHandler>();
builder.Services.AddScoped<DeleteStudioHandler>();
builder.Services.AddScoped<GetStudiosHandler>();
builder.Services.AddScoped<UpdateStudioHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
