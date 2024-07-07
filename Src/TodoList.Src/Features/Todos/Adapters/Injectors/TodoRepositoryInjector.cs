using TodoList.Src.Features.Todos.Adapters.Database.Postgres.Repositories;
using TodoList.Src.Features.Todos.Domain.Ports;
using TodoList.Src.TodoList.Src.Features.Todos.Adapters.Database.Dynamo.Repositories;

namespace TodoList.Src.Features.Todos.Adapters.Injectors;

public static class TodoRepositoryInjector
{
    public static IServiceCollection AddTodoRepositories(this IServiceCollection services)
    => services
            .AddScoped<ITodoRepository, PostgresTodoRepository>()
            .AddScoped<ITodoProcessingRepostory, DynamoProcessingTodoRepository>()
    ;
}
