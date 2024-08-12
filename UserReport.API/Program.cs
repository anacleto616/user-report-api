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

// Add services to the container.
builder.Services.AddDbContext<UserReportContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserPersist, UserReportPersist>();

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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Lógica de inicialização para salvar o usuário ao iniciar a aplicação
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var userService = services.GetRequiredService<IUserService>();

        // Chama o serviço para adicionar o usuário a partir da API externa
        var savedUsers = await userService.AddUsers(10);

        if (savedUsers != null)
        {
            Console.WriteLine($"User was saved successfully!");
        }
        else
        {
            Console.WriteLine("User could not be saved.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error occurred: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
