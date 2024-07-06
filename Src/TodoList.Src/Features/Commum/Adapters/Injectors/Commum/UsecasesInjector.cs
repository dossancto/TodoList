using TodoList.Src.Features.Todos.Adapters.Injectors;

namespace TodoList.Src.Features.Commum.Adapters.Injectors.Commum;

public static class UsecasesInjector
{
    public static IServiceCollection AddUscases(this IServiceCollection services)
    => services
            .AddTodoUsecases()
            ;
}
