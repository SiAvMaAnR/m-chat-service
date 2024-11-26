using Chat.WebApi.RMQListeners.Accounts;
using Chat.WebApi.RMQListeners.Chat;

namespace Chat.WebApi.ApiBuilder.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddHostedDependencies(
        this IServiceCollection serviceCollection
    )
    {
        serviceCollection.AddHostedService<AccountsRMQService>();
        serviceCollection.AddHostedService<ChatRMQService>();

        return serviceCollection;
    }
}
