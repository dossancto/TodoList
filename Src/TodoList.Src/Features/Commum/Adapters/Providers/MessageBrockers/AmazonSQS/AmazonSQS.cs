using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;
using TodoList.Src.TodoList.Src.Features.Commum.Domain.Entities.MessageBrockers.Enums;
using TodoList.Src.TodoList.Src.Features.Commum.Domain.Ports.MessageBrockers;

namespace TodoList.Src.TodoList.Src.Features.Commum.Adapters.Providers.MessageBrockers.AmazonSQS;

public class AmazonSQS(
      IAmazonSQS _sqs
    ) : IMessageBrocker
{
    private readonly IAmazonSQS sqs = _sqs;

    public async Task<string> SendMessageAsync(QueueName queue, object message)
    {
        var body = JsonSerializer.Serialize(message);
        var queueUrl = await sqs.QueueUrl(queue);

        var sendMessageRequest = new SendMessageRequest
        {
            QueueUrl = queueUrl,
            MessageGroupId = queue.ToString(),
            MessageBody = body,
        };

        var res = await sqs.SendMessageAsync(sendMessageRequest);

        return res.MessageId;
    }

}
