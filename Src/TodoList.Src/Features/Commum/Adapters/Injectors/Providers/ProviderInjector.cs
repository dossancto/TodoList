namespace TodoList.Src.Features.Commum.Adapters.Injectors.Providers;

public static class ProviderInjector
{
    public static IServiceCollection AddProviders(this IServiceCollection services)
    => services
            .AddValidators()
            .AddMessageBrockers()
    ;
}
