using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace TodoList.Src.TodoList.Src.Features.Commum.Adapters.Extensions.Providers;

public static class DynamoExtensions
{
    public static DynamoDBContext Context(this IAmazonDynamoDB dynamo)
      => new(dynamo);
}
