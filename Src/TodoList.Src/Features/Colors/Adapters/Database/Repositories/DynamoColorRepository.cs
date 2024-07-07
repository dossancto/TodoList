using Amazon.DynamoDBv2;
using TodoList.Src.TodoList.Src.Features.Colors.Adapters.Database.Entities;
using TodoList.Src.TodoList.Src.Features.Colors.Application.DeleteColor;
using TodoList.Src.TodoList.Src.Features.Colors.Application.SelectColor;
using TodoList.Src.TodoList.Src.Features.Colors.Domain.Entities;
using TodoList.Src.TodoList.Src.Features.Colors.Domain.Ports;
using TodoList.Src.TodoList.Src.Features.Commum.Adapters.Extensions.Providers;

namespace TodoList.Src.TodoList.Src.Features.Colors.Adapters.Database.Repositories;

public class DynamoColorRepository(
      IAmazonDynamoDB dynamo
    ) : IColorRepository
{

    public async Task Create(Color c)
    {
        var model = new DynamoColorEntity(c);

        var context = dynamo.Context();

        await context.SaveAsync(model);
    }

    public async Task Delete(DeleteColorInput input)
    {
        var context = dynamo.Context();

        var model = new DynamoColorEntity(
            Name: input.Name,
            Description: "",
            HexCode: ""
            );

        await context.DeleteAsync(model);
    }

    public async Task<Color?> GetColorByName(SelectColorInput input)
    {
        var context = dynamo.Context();

        var res = await context.LoadAsync<DynamoColorEntity?>(input.ColorName);

        return res?.ToColor();
    }
}
