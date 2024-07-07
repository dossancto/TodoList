using TodoList.Src.Features.Todos.Adapters.Injectors;

namespace TodoList.Src.Features.Commum.Adapters.Injectors.Commum;

public static class ModuleInjector
{
    public static IServiceCollection AddModules(this IServiceCollection services)
    => services
            .AddTodoModule()
            ;
}

