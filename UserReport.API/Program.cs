using Microsoft.EntityFrameworkCore;
using UserReport.Persistence.Contexts;

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

app.Run();
