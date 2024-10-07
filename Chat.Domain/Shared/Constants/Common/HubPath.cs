namespace Chat.Domain.Shared.Constants.Common;

public static class HubPath
{
    private const string HubPathPrefix = "/signalR";

    public const string Chat = $"{HubPathPrefix}/chat";
    public const string State = $"{HubPathPrefix}/state";
}
