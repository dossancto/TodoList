using TodoList.Src.Features.Todos.Application.SelectTodo;
using TodoList.Src.Features.Todos.Domain.Entities;
using TodoList.Src.TodoList.Src.Features.Todos.Application.ToggleProcessingTodo;

namespace TodoList.Src.Features.Todos.Domain.Ports;

public interface ITodoProcessingRepostory
{
    Task<bool> IsBeeingProcessedAsync(FindProcessingTodoInput input);

    Task SetTodoAsProcessing(SetProcessingTodoInput input);

    Task RemoveTodoFromProcessing(RemoveProcessingTodoInput input);
}
