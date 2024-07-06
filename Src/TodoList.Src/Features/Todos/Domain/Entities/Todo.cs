namespace TodoList.Src.Features.Todos.Domain.Entities;

/// <summary>
///  This class represents a todo contract
/// </summary>
public record Todo(string Id, string Name, string Description, bool Completed, DateTime CreatedAt)
{
    public Todo() : this("", "", "", default, default) { }
}
