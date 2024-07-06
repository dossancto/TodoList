using TodoList.Src.TodoList.Src.Features.Colors.Adapters.Database.Repositories;
using TodoList.Src.TodoList.Src.Features.Colors.Domain.Ports;

namespace TodoList.Src.TodoList.Src.Features.Colors.Adapters.Injetors;

public static class ColorRepositoryInjector
{
    public static IServiceCollection AddColorRepositories(this IServiceCollection services)
      => services
            .AddScoped<IColorRepository, DynamoColorRepository>()
      ;
}
