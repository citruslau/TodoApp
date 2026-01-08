using Microsoft.EntityFrameworkCore;
using TodoApi;
using TodoApi.Models; // Import models for future use

var builder = WebApplication.CreateBuilder(args);

// Register the Database Context
builder.Services.AddDbContext<TodoDb>(opt =>
    opt.UseSqlite("Data Source=todos.db"));

var app = builder.Build();

app.MapGet("/", () => "Todo API is running.");

app.Run();