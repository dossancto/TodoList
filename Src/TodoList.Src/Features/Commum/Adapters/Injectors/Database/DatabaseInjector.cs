using Microsoft.EntityFrameworkCore;
using TodoList.Src.Features.Commum.Adapters.Configs;
using TodoList.Src.Features.Commum.Adapters.Database.EntityFramework.Contexts;

namespace TodoList.Src.Features.Commum.Adapters.Injectors.Database;

public static class DatabaseInjector
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        var connectionString = AppEnv.Postgres.CONNECTION_STRING.NotNull();

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        return services;
    }
}