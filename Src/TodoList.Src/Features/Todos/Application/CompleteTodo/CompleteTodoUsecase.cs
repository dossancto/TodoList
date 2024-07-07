using TodoList.Src.Features.Todos.Application.SelectTodo;
using TodoList.Src.TodoList.Src.Features.Commum.Domain.Entities.MessageBrockers.Enums;
using TodoList.Src.TodoList.Src.Features.Commum.Domain.Ports.MessageBrockers;
using TodoList.Src.TodoList.Src.Features.Todos.Application.ToggleProcessingTodo;
using TodoList.Src.TodoList.Src.Features.Todos.Domain.Exceptions;

namespace TodoList.Src.TodoList.Src.Features.Todos.Application.CompleteTodo;

public class CompleteTodoUsecase(
    IMessageBrocker messageBrocker,
    SelectTodoUsecase selectTodo,
    ToggleProcessingTodoUsecase toggleProcessing
    )
{
    private readonly IMessageBrocker messageBrocker = messageBrocker;
    private readonly SelectTodoUsecase selectTodo = selectTodo;
    private readonly ToggleProcessingTodoUsecase toggleProcessing = toggleProcessing;

    /// <summary>
    /// Proccess the todo completition in background
    /// </summary>
    /// <returns> The message id </returns>
    public async Task<string> Execute(CompleteTodoInput input)
    {
        var alrearyProcessed = await selectTodo.Execute(new FindProcessingTodoInput(
              TodoId: input.TodoId
              )
        );

        if (alrearyProcessed)
        {
            throw new TodoAlrearyBeenProcessedException();
        }

        var todo = await selectTodo.Execute(new SelectTodoByIdInput(
              Id: input.TodoId
              ));

        if (todo is null)
        {
            throw new("Todo not found");
        }

        var messageId = await messageBrocker.SendMessageAsync(QueueName.CompleteTodo, todo);

        await toggleProcessing.Execute(new SetProcessingTodoInput(
              TodoId: input.TodoId
            ));

        return messageId;
    }
}
