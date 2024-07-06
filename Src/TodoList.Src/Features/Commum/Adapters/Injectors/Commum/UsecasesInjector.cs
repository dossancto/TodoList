using TodoList.Src.Features.Todos.Adapters.Injectors;
using TodoList.Src.TodoList.Src.Features.Colors.Adapters.Injetors;

namespace TodoList.Src.Features.Commum.Adapters.Injectors.Commum;

public static class UsecasesInjector
{
    public static IServiceCollection AddUscases(this IServiceCollection services)
    => services
            .AddTodoUsecases()
            .AddColorUsecases()
            ;
}
