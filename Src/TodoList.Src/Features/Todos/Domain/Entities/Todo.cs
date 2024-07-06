namespace TodoList.Src.Features.Todos.Domain.Entities;

/// <summary>
///  This class represents a todo contract
/// </summary>
public class Todo
{
    public string Id {get ;set;} = string.Empty;

    /// <summary>
    /// This is the name of the todo
    /// </summary>
    public string Name {get; set;} = string.Empty;

    public string Description {get; set;} = string.Empty;

    public bool Completed {get; set;}

    public DateTime CreatedAt {get; set;}
}