using GameDex.Core.DataHelper;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactPort", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });


builder.Services.AddScoped<GamesHelper>();

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


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowReactPort");

app.MapControllers();

app.Run();
