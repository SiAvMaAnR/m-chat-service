using Chat.Domain.Common;

namespace Chat.Infrastructure.RabbitMQ;

public class RabbitMQConsumer : IRabbitMQConsumer
{
    private readonly IAppSettings _appSettings;

    public RabbitMQConsumer(IAppSettings appSettings)
    {
        _appSettings = appSettings;
    }
}
