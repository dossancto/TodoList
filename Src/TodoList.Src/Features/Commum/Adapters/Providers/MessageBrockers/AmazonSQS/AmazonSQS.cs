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

    public async Task Consume(QueueName queue, Func<string, Task<MessageBrokerAckType>> consumeFunc, CancellationToken stoppingToken)
    {
        var continueNext = () => Task.Delay(1000, stoppingToken);
        var queueUrl = await sqs.QueueUrl(queue);

        var receiveMessageRequest = new ReceiveMessageRequest
        {
            QueueUrl = queueUrl,
            MaxNumberOfMessages = 1,
            WaitTimeSeconds = 0
        };

        while (!stoppingToken.IsCancellationRequested)
        {
            var receiveMessageResponse = await sqs.ReceiveMessageAsync(receiveMessageRequest, stoppingToken);

            if (receiveMessageResponse.Messages.Count == 0)
            {
                await continueNext();
                continue;
            }

            foreach (var msg in receiveMessageResponse.Messages)
            {
                var body = msg.Body;

                var ack = await consumeFunc(body);

                switch (ack)
                {
                    case (MessageBrokerAckType.ACK):
                    case (MessageBrokerAckType.REJECT):
                        await DeleteMessage(queueUrl, msg, stoppingToken);
                        break;
                }
            }

            await continueNext();
        }
    }

    private async Task<DeleteMessageResponse> DeleteMessage(string queueUrl, Message msg, CancellationToken stoppingToken)
    {
        var deleteMessageRequest = new DeleteMessageRequest
        {
            QueueUrl = queueUrl,
            ReceiptHandle = msg.ReceiptHandle
        };

        return await sqs.DeleteMessageAsync(deleteMessageRequest, stoppingToken);
    }
}
