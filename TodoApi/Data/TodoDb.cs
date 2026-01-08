using Microsoft.EntityFrameworkCore;
using TodoApi.Models; // We must import the Models namespace

namespace TodoApi.Data;

public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
}