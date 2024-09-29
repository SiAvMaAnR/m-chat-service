using ChatService.Domain.Common;

namespace ChatService.Infrastructure.RabbitMQ;

public class RabbitMQConsumer : IRabbitMQConsumer
{
    private readonly IAppSettings _appSettings;

    public RabbitMQConsumer(IAppSettings appSettings)
    {
        _appSettings = appSettings;
    }
}
