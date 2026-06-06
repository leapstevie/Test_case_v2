using Microsoft.EntityFrameworkCore;
using SV35.POS.Data;

var builder = WebApplication.CreateBuilder(args);

// MAMP MySQL: Server=localhost;Port=8889;Database=SV35POS;User=root;Password=root;
// Fallback (Local MySQL): Server=localhost;Port=3306;Database=SV35POS;User=root;Password=;
var connectionString = @"Server=localhost;Port=8889;Database=SV35POS;User=root;Password=root;";
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();