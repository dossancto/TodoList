using TodoList.Src.Features.Todos.Domain.Entities;

namespace TodoList.Src.Features.Todos.Application.CreateTodo;

public class CreateTodoInput
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public Todo ToTodo()
    => new (){
        Name = Name,
        Description = Description ?? string.Empty,
        Completed = false,
        CreatedAt = DateTime.UtcNow,
    };
}