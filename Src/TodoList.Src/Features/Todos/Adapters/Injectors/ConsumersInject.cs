using TodoList.Src.TodoList.Src.Features.Todos.Adapters.UI.BackgroundJobs;

namespace TodoList.Src.Features.Todos.Adapters.Injectors;

public static class ConsumersInject
{
    public static IServiceCollection AddTodoConsumers(this IServiceCollection services)
    {
        services.AddHostedService<ConsumeCompleteTodoJob>();

        return services;
    }
}

