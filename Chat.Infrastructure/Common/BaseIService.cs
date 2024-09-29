using Chat.Domain.Common;
using Chat.Infrastructure.RabbitMQ;

namespace Chat.Infrastructure.Services.Common;

public abstract class BaseIService(IAppSettings appSettings, IRabbitMQProducer rabbitMQProducer)
{
    protected readonly IAppSettings _appSettings = appSettings;
    protected readonly IRabbitMQProducer _rabbitMQProducer = rabbitMQProducer;
}
