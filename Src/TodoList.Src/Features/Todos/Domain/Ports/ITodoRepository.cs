using TodoList.Src.Features.Todos.Application.DeleteTodo;
using TodoList.Src.Features.Todos.Application.SelectTodo;
using TodoList.Src.Features.Todos.Domain.Entities;

namespace TodoList.Src.Features.Todos.Domain.Ports;

public interface ITodoRepository
{
    Task<string> Create(Todo todo);

    Task<Todo?> FindById(SelectTodoByIdInput input);

    Task<IEnumerable<Todo>> All(SelectAllTodos input);

    Task Delete(DeleteTodoInput input);

    Task Update(Todo todo);
}
