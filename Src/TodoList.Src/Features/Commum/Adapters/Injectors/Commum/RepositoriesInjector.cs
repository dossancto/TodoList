using TodoList.Src.Features.Todos.Adapters.Injectors;
using TodoList.Src.TodoList.Src.Features.Colors.Adapters.Injetors;

namespace TodoList.Src.Features.Commum.Adapters.Injectors.Commum;

public static class RepositoriesInjector
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    => services
            .AddTodoRepositories()
            .AddColorRepositories()
            ;
}
