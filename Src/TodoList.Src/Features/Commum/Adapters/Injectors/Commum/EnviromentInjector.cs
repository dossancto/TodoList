using DotNetEnv;

namespace TodoList.Src.Features.Commum.Adapters.Injectors.Commum;

public static class EnviromentInjector
{
    public static IServiceCollection AddEnvirioment(this IServiceCollection services)
    {
        Env.TraversePath().Load();

        return services;
    }
}