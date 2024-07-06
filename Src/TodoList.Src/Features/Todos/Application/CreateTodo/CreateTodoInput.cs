using TodoList.Src.Features.Todos.Domain.Entities;

namespace TodoList.Src.Features.Todos.Application.CreateTodo;

/// <summary>
///  This class represents a todo contract
/// </summary>
public record CreateTodoInput(string Name, string? Description = null)
{
    public Todo ToTodo()
    => new()
    {
        Name = Name,
        Description = Description ?? "none",
        Completed = false,
        CreatedAt = DateTime.UtcNow,
    };
}
