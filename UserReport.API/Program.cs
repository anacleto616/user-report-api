using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using UserReport.Application;
using UserReport.Application.Interfaces;
using UserReport.Persistence;
using UserReport.Persistence.Contexts;
using UserReport.Persistence.Interfaces;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load("../.env.development");

var connectionString =
    $"Host={Environment.GetEnvironmentVariable("POSTGRES_HOST")};"
    + $"Port={Environment.GetEnvironmentVariable("POSTGRES_PORT")};"
    + $"Database={Environment.GetEnvironmentVariable("POSTGRES_DB")};"
    + $"Username={Environment.GetEnvironmentVariable("POSTGRES_USER")};"
    + $"Password={Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")}";

builder.Services.AddDbContext<UserReportContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<IUserPersist, UserReportPersist>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();

builder.Services.AddHttpClient(
    "IRandomUserApi",
    client =>
    {
        client.BaseAddress = new Uri("https://randomuser.me");
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json")
        );
    }
);

builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var userService = services.GetRequiredService<IUserService>();

        var users = await userService.GetAllUsersAsync();

        if (users.Count > 10)
        {
            Console.WriteLine("There are already registered users.");
        }
        else
        {
            var savedUsers = await userService.AddUsers(10);

            if (savedUsers != null)
            {
                Console.WriteLine($"Users was saved successfully!");
            }
            else
            {
                Console.WriteLine("Users could not be saved.");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error occurred: {ex.Message}");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapControllers();

app.Run();
