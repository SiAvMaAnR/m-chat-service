namespace Messenger.Domain.Shared.Settings;

public class RoutePathSettings : ISettings
{
    public static string Path => "RoutePath";

    public string ConfirmRegistration { get; set; } = null!;
    public string ResetToken { get; set; } = null!;
}
