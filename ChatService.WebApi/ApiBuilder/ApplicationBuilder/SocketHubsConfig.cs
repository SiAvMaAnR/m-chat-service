using ChatService.Domain.Shared.Constants.Common;
using ChatService.WebApi.Hubs;

namespace ChatService.WebApi.ApiBuilder.ApplicationBuilder;

public static partial class ApplicationBuilderExtension
{
    public static void HubsConfiguration(this WebApplication webApplication)
    {
        webApplication.MapHub<ChatHub>(HubPath.Chat);
        webApplication.MapHub<StateHub>(HubPath.State);
    }
}
