using ChatService.Domain.Common;
using ChatService.Infrastructure.AppSettings;
using ChatService.WebApi.Common;
using StackExchange.Redis;

namespace ChatService.WebApi.ApiBuilder.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddSingletonDependencies(
        this IServiceCollection serviceCollection,
        IConfiguration config
    )
    {
        string connection = AppEnvironment.GetRedisConnectionString(config);

        serviceCollection.AddSingleton<IAppSettings, AppSettings>();
        serviceCollection.AddSingleton<IConnectionMultiplexer>(
            ConnectionMultiplexer.Connect(connection)
        );

        return serviceCollection;
    }
}
