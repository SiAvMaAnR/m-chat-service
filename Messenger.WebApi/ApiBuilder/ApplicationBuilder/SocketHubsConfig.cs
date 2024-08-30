using Messenger.Domain.Shared.Constants.Common;
using Messenger.WebApi.Hubs;

namespace Messenger.WebApi.ApiBuilder.ApplicationBuilder;

public static partial class ApplicationBuilderExtension
{
    public static void HubsConfiguration(this WebApplication webApplication)
    {
        webApplication.MapHub<ChatHub>(HubPath.Chat);
        webApplication.MapHub<StateHub>(HubPath.State);
    }
}
