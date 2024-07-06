using TodoList.Src.Features.Todos.Adapters.Database.Repositories;
using TodoList.Src.Features.Todos.Domain.Ports;

namespace TodoList.Src.Features.Todos.Adapters.Injectors;

public static class TodoRepositoryInjector
{
    public static IServiceCollection AddTodoRepositories(this IServiceCollection services)
    => services
            .AddScoped<ITodoRepository, PostgresTodoRepository>()
    ;
}