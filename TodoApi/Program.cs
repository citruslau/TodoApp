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

// PUT: Update an existing Todo item
app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.TaskName = inputTodo.TaskName;
    todo.IsCompleted = inputTodo.IsCompleted;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

// DELETE: Remove a Todo item
app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }

    return Results.NotFound();
});

app.Run();