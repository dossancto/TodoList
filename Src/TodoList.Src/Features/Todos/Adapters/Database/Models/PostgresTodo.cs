using TodoList.Src.Features.Todos.Domain.Entities;

namespace TodoList.Src.Features.Todos.Adapters.Database.Models;

public record PostgresTodo(string Id, string Name, string Description, bool Completed, DateTime CreatedAt)
{
    public PostgresTodo() : this("", "", "", default, default) { }

    public static PostgresTodo AsPostgres(Todo t)
    => new(
        Id: t.Id,
        Name: t.Name,
        Description: t.Description,
        Completed: t.Completed,
        CreatedAt: t.CreatedAt
      );

    public Todo AsEntity()
    => new(
        Id: Id,
        Name: Name,
        Description: Description,
        Completed: Completed,
        CreatedAt: CreatedAt
      );
}
