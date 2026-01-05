using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models;

public class TodoItem
{
    public int Id { get; set; }

    [Required]
    public string TaskName { get; set; } = string.Empty;
    public bool isCompleted { get; set; } = false;

}