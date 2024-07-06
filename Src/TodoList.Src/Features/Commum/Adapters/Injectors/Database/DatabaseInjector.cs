using Amazon;
using Amazon.DynamoDBv2;
using Microsoft.EntityFrameworkCore;
using TodoList.Src.Features.Commum.Adapters.Configs;
using TodoList.Src.Features.Commum.Adapters.Database.EntityFramework.Contexts;

namespace TodoList.Src.Features.Commum.Adapters.Injectors.Database;

public static class DatabaseInjector
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
      => services
            .AddPostgresDatabase()
            .AddDynamoDatabase()
      ;

    private static IServiceCollection AddPostgresDatabase(this IServiceCollection services)
    {
        var connectionString = AppEnv.Postgres.CONNECTION_STRING.NotNull();

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        return services;
    }

    private static IServiceCollection AddDynamoDatabase(this IServiceCollection services)
      => services.AddSingleton<IAmazonDynamoDB>(_ => GetDynamoClient());

    private static AmazonDynamoDBClient GetDynamoClient()
    {
        var profile = AppEnv.AWS.PROFILE;

        if (profile.IsNotDefined())
        {
            return new();
        }

        var credentialProfile = new Amazon.Runtime.CredentialManagement.CredentialProfileStoreChain()
                    .TryGetAWSCredentials(profile.NotNull(), out var credentials);

        if (!credentialProfile)
        {
            return new();
        }

        var config = new AmazonDynamoDBConfig()
        {
            ServiceURL = AppEnv.AWS.ENDPOINT.NotNull(),
            RegionEndpoint = RegionEndpoint.GetBySystemName(AppEnv.AWS.REGION.NotNull())
        };

        return new(credentials: credentials, clientConfig: config);
    }
}
