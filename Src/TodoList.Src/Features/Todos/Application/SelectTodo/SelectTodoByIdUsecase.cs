using TodoList.Src.Features.Todos.Domain.Entities;
using TodoList.Src.Features.Todos.Domain.Ports;

namespace TodoList.Src.Features.Todos.Application.SelectTodo;

public class SelectTodoUsecase(
    ITodoRepository todoRepository
)
{
    private readonly ITodoRepository _todoRepository = todoRepository;

    public Task<Todo?> Execute(SelectTodoByIdInput input)
    => _todoRepository.FindById(input);

    public Task<IEnumerable<Todo>> Execute(SelectAllTodos input)
    => _todoRepository.All(input);
}