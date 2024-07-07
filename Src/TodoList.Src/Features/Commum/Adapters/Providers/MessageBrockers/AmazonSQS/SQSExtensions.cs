using Amazon.SQS;
using TodoList.Src.TodoList.Src.Features.Commum.Domain.Entities.MessageBrockers.Enums;

namespace TodoList.Src.TodoList.Src.Features.Commum.Adapters.Providers.MessageBrockers.AmazonSQS;

public static class SQSExtensions
{
    public static async Task<string> QueueUrl(this IAmazonSQS sqs, QueueName queue)
      => (await sqs.GetQueueUrlAsync(queue.QueueUrl())).QueueUrl;

    public static string QueueUrl(this QueueName queue)
      => queue switch
      {
          QueueName.CompleteTodo => "complete_todo.fifo",
          _ => throw new NotImplementedException($"Queue {queue.ToString()} not supported")
      };

}

