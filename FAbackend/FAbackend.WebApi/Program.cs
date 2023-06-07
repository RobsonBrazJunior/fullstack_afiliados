using FAbackend.Application.Interfaces;
using FAbackend.Application.Services;
using FAbackend.Infra.Data.Context;
using FAbackend.Infra.Data.Repository.Interfaces;
using FAbackend.Infra.Data.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
	.SetBasePath(builder.Environment.ContentRootPath)
	.AddJsonFile("appsettings.json", true, true)
	.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
	.AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
		p => p.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), null).MigrationsHistoryTable("_version_migration"));
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICreatorService, CreatorService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
