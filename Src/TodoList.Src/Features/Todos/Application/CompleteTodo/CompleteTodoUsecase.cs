using TodoList.Src.Features.Todos.Application.SelectTodo;
using TodoList.Src.TodoList.Src.Features.Commum.Domain.Entities.MessageBrockers.Enums;
using TodoList.Src.TodoList.Src.Features.Commum.Domain.Ports.MessageBrockers;

namespace TodoList.Src.TodoList.Src.Features.Todos.Application.CompleteTodo;

public class CompleteTodoUsecase(
    IMessageBrocker messageBrocker,
    SelectTodoUsecase selectTodo
    )
{
    private readonly IMessageBrocker messageBrocker = messageBrocker;

    /// <summary>
    /// Proccess the todo completition in background
    /// </summary>
    /// <returns> The message id </returns>
    public async Task<string> Execute(CompleteTodoInput input)
    {
        var todo = await selectTodo.Execute(new SelectTodoByIdInput(
              Id: input.TodoId
              ));

        if (todo is null)
        {
            throw new("Todo not found");
        }

        var messageId = await messageBrocker.SendMessageAsync(QueueName.CompleteTodo, todo);

        return messageId;
    }
}
