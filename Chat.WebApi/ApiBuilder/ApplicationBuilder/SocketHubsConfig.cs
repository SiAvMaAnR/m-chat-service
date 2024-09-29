using Chat.Domain.Shared.Constants.Common;
using Chat.WebApi.Hubs;

namespace Chat.WebApi.ApiBuilder.ApplicationBuilder;

public static partial class ApplicationBuilderExtension
{
    public static void HubsConfiguration(this WebApplication webApplication)
    {
        webApplication.MapHub<ChatHub>(HubPath.Chat);
        webApplication.MapHub<StateHub>(HubPath.State);
    }
}
