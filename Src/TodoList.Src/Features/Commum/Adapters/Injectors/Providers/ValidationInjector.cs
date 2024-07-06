using FluentValidation;

namespace TodoList.Src.Features.Commum.Adapters.Injectors.Providers;

public static class ValidationInjector
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<Program>();

        return services;
    }
}