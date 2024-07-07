namespace TodoList.Src.Features.Todos.Adapters.Injectors;

public static class TodoModuleInject
{
    public static IServiceCollection AddTodoModule(this IServiceCollection services)
    => services
              .AddTodoRepositories()
              .AddTodoUsecases()
              .AddTodoConsumers()
    ;
}

