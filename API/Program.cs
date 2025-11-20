using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Infrastructure.Context;
using Core;
using Infrastructure;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection"));
});

builder.Services.AddCoreDependencies();
builder.Services.AddServicesDependence();
builder.Services.AddInfrastructureDependence();

// 1. Add CORS



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin() // أو SetIsOriginAllowed(origin => true)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});



builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate(); // أو db.Database.Migrate();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
