using TodoList.Src.TodoList.Src.Features.Commum.Domain.Entities.MessageBrockers.Enums;

namespace TodoList.Src.TodoList.Src.Features.Commum.Domain.Ports.MessageBrockers;

public interface IMessageBrocker
{
    Task<string> SendMessageAsync(QueueName queue, object message);

    Task Consume(QueueName queue, Func<string, Task<MessageBrokerAckType>> consumeFunc, CancellationToken stoppingToken);
}
