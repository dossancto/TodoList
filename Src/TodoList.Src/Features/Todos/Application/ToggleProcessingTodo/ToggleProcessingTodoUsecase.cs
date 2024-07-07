using TodoList.Src.Features.Todos.Domain.Ports;

namespace TodoList.Src.TodoList.Src.Features.Todos.Application.ToggleProcessingTodo;

public class ToggleProcessingTodoUsecase(
    ITodoProcessingRepostory _todoProcess
    )
{
    private readonly ITodoProcessingRepostory todoProcess = _todoProcess;

    public async Task Execute(SetProcessingTodoInput input)
    {
        await todoProcess.SetTodoAsProcessing(input);
    }

    public async Task Execute(RemoveProcessingTodoInput input)
    {
        await todoProcess.RemoveTodoFromProcessing(input);
    }
}
