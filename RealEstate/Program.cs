using RealEstate.Data;
using Microsoft.EntityFrameworkCore;
using RealEstate.Infrastructure.Repositories;
using RealEstate.Application.Interfaces;
using RealEstate.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.AllowAnyOrigin() // Allow the Angular app
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add DbContext for SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Register repository and service for DI
builder.Services.AddScoped<HouseRepository>();
builder.Services.AddScoped<IHouseService, HouseService>();
builder.Services.AddScoped<ApplicationRepository>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use CORS
app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
