using Amazon.DynamoDBv2;
using TodoList.Src.Features.Todos.Application.SelectTodo;
using TodoList.Src.Features.Todos.Domain.Ports;
using TodoList.Src.TodoList.Src.Features.Commum.Adapters.Extensions.Providers;
using TodoList.Src.TodoList.Src.Features.Todos.Adapters.Database.Dynamo.Entities;
using TodoList.Src.TodoList.Src.Features.Todos.Application.ToggleProcessingTodo;

namespace TodoList.Src.TodoList.Src.Features.Todos.Adapters.Database.Dynamo.Repositories;

public class DynamoProcessingTodoRepository(
    IAmazonDynamoDB _dynamo
    ) : ITodoProcessingRepostory
{
    private readonly IAmazonDynamoDB dynamo = _dynamo;

    public async Task<bool> IsBeeingProcessedAsync(FindProcessingTodoInput input)
    {
        var context = dynamo.Context();

        var res = await context.LoadAsync<DynamoProcessingTodo?>(input.TodoId);

        return res is not null;
    }

    public async Task RemoveTodoFromProcessing(RemoveProcessingTodoInput input)
    {
        var model = new DynamoProcessingTodo(
            TodoId: input.TodoId,
            StartProcessing: DateTime.UtcNow
          );

        var context = dynamo.Context();

        await context.DeleteAsync(model);
    }

    public async Task SetTodoAsProcessing(SetProcessingTodoInput input)
    {
        var model = new DynamoProcessingTodo(
            TodoId: input.TodoId,
            StartProcessing: DateTime.UtcNow
          );

        var context = dynamo.Context();

        await context.SaveAsync(model);
    }
}
