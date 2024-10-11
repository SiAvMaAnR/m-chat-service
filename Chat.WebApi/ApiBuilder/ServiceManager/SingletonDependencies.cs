using Chat.Domain.Common;
using Chat.Infrastructure.AppSettings;
using Chat.Infrastructure.RabbitMQ;
using Chat.WebApi.Common;
using StackExchange.Redis;

namespace Chat.WebApi.ApiBuilder.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddSingletonDependencies(
        this IServiceCollection serviceCollection,
        IConfiguration config
    )
    {
        string connection = AppEnvironment.GetRedisConnectionString(config);

        serviceCollection.AddSingleton<IAppSettings, AppSettings>();
        serviceCollection.AddSingleton<IRabbitMQProducer, RabbitMQProducer>();
        serviceCollection.AddSingleton<IRabbitMQConsumer, RabbitMQConsumer>();
        serviceCollection.AddSingleton<IConnectionMultiplexer>(
            ConnectionMultiplexer.Connect(connection)
        );

        return serviceCollection;
    }
}
