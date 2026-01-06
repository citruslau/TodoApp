using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data;

public class TodoDB : DbContext
{
    public TodoDB(DbContextOptions<TodoDB> options)
    : base(options) { }

    public DbSet<TodoItem> Todos => Set<TodoItem>();
}