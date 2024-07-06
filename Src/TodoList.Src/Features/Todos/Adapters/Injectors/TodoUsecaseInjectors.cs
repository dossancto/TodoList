using TodoList.Src.Features.Todos.Application.CreateTodo;

namespace TodoList.Src.Features.Todos.Adapters.Injectors;

public static class TodoUsecaseInjectors
{
    public static IServiceCollection AddTodoUsecases(this IServiceCollection services)
    => services
            .AddScoped<CreateTodoUsecase>()
    ;
}