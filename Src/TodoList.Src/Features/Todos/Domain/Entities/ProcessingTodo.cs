namespace TodoList.Src.TodoList.Src.Features.Todos.Domain.Entities;

public record ProcessingTodo(
    string TodoId,
    DateTime StartProcessing
  );
