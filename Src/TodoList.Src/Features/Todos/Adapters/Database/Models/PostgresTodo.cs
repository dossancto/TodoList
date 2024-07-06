using TodoList.Src.Features.Todos.Domain.Entities;

namespace TodoList.Src.Features.Todos.Adapters.Database.Models;

public class PostgresTodo
{
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// This is the name of the todo
    /// </summary>
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool Completed { get; set; }

    public DateTime CreatedAt { get; set; }

    public static PostgresTodo AsPostgres(Todo t)
    => new()
    {
        Id = t.Id,
        Completed = t.Completed,
        CreatedAt = t.CreatedAt,
        Description = t.Description,
        Name = t.Name,
    };

    public Todo AsEntity()
    => new()
    {
        Id = Id,
        Completed = Completed,
        CreatedAt = CreatedAt,
        Description = Description,
        Name = Name,
    };
}