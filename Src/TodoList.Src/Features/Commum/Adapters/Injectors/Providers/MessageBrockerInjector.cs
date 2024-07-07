using Amazon;
using Amazon.SQS;
using TodoList.Src.TodoList.Src.Features.Commum.Adapters.Providers.MessageBrockers.AmazonSQS;
using TodoList.Src.TodoList.Src.Features.Commum.Domain.Ports.MessageBrockers;

namespace TodoList.Src.Features.Commum.Adapters.Injectors.Providers;

public static class MessageBrockerInjector
{
    public static IServiceCollection AddMessageBrockers(this IServiceCollection services)
    => services
            .AddAWSSQS()
    ;

    private static IServiceCollection AddAWSSQS(this IServiceCollection services)
    {
        var client = GetSQSClient();
        services.AddSingleton<IAmazonSQS>(_ => client);

        services.AddScoped<IMessageBrocker, AmazonSQS>();

        return services;
    }

    private static AmazonSQSClient GetSQSClient()
    {
        var profile = Configs.AppEnv.AWS.PROFILE;

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

        var config = new AmazonSQSConfig()
        {
            RegionEndpoint = RegionEndpoint.GetBySystemName(Configs.AppEnv.AWS.REGION.NotNull())
        };

        if (Configs.AppEnv.AWS.ENDPOINT.IsDefined())
        {
            config.ServiceURL = Configs.AppEnv.AWS.ENDPOINT.NotNull();
        }

        return new(credentials: credentials, clientConfig: config);
    }
}

