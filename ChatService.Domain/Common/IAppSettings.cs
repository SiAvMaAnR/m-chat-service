using ChatService.Domain.Shared.Settings;

namespace ChatService.Domain.Common;

public interface IAppSettings
{
    CommonSettings Common { get; }
    RoutePathSettings RoutePath { get; }
    FilePathSettings FilePath { get; }
    ClientSettings Client { get; }
    AuthSettings Auth { get; }
    RMQSettings RMQ { get; }
}
