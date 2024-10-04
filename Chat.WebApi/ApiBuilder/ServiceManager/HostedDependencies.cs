using Chat.WebApi.RMQServices;

namespace Chat.WebApi.ApiBuilder.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddHostedDependencies(
        this IServiceCollection serviceCollection
    )
    {
        serviceCollection.AddHostedService<AccountsRMQService>();

        return serviceCollection;
    }
}
