using System.Text.Json;
using TodoList.Src.Features.Todos.Domain.Entities;
using TodoList.Src.TodoList.Src.Features.Commum.Domain.Entities.MessageBrockers.Enums;
using TodoList.Src.TodoList.Src.Features.Commum.Domain.Ports.MessageBrockers;
using TodoList.Src.TodoList.Src.Features.Todos.Application.CompleteTodo;
using TodoList.Src.TodoList.Src.Features.Todos.Application.ToggleProcessingTodo;

namespace TodoList.Src.TodoList.Src.Features.Todos.Adapters.UI.BackgroundJobs;

public class ConsumeCompleteTodoJob(IServiceProvider _serviceProvider) : BackgroundService
{
    /// <summary>
    /// Run the service
    /// </summary>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceProvider.CreateScope();

        var messageBroker = scope.ServiceProvider.GetRequiredService<IMessageBrocker>();
        var completeTodo = scope.ServiceProvider.GetRequiredService<CompleteTodoUsecase>();

        var handleFunc = async (string msg) =>
        {
            var todo = JsonSerializer.Deserialize<Todo>(msg);

            if (todo is null)
            {
                return MessageBrokerAckType.REJECT;
            }

            await completeTodo.Execute(new CompleteTodoInput(
                TodoId: todo.Id
            ));

            return MessageBrokerAckType.ACK;
        };

        await messageBroker.Consume(QueueName.CompleteTodo, handleFunc, stoppingToken);
    }
}

