using TodoList.Src.Features.Commum.Adapters.Injectors.Database;

namespace TodoList.Src.Features.Commum.Adapters.Injectors.Commum;

public static class ApplicationInjector
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    => services
            .AddEnvirioment()
            .AddDatabase()
    ;
}