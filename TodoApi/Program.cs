using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models; // Import models for future use

var builder = WebApplication.CreateBuilder(args);

// Register the Database Context
builder.Services.AddDbContext<TodoDb>(opt =>
    opt.UseSqlite("Data Source=todos.db"));

var app = builder.Build();

app.MapGet("/", () => "Todo API is running.");

// GET: Fetch all Todo items
app.MapGet("/todoitems", async (TodoDb db) =>
    await db.Todos.ToListAsync());

// POST Create a new Todo item
app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});


app.Run();