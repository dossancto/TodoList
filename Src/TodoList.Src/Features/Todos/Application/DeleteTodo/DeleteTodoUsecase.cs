using TodoList.Src.Features.Todos.Domain.Ports;

namespace TodoList.Src.Features.Todos.Application.DeleteTodo;

public class DeleteTodoUsecase(
    ITodoRepository todoRepository
)
{
    public Task Execute(DeleteTodoInput input)
    => todoRepository.Delete(input);
}
