using Chat.WebApi.RMQListeners.Accounts;
using Chat.WebApi.RMQListeners.AI;

namespace Chat.WebApi.ApiBuilder.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddHostedDependencies(
        this IServiceCollection serviceCollection
    )
    {
        serviceCollection.AddHostedService<AccountsRMQService>();
        serviceCollection.AddHostedService<AIRMQService>();

        return serviceCollection;
    }
}
