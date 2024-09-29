using ChatService.Domain.Common;
using ChatService.Infrastructure.RabbitMQ;

namespace ChatService.Infrastructure.Services.Common;

public abstract class BaseIService(IAppSettings appSettings, IRabbitMQProducer rabbitMQProducer)
{
    protected readonly IAppSettings _appSettings = appSettings;
    protected readonly IRabbitMQProducer _rabbitMQProducer = rabbitMQProducer;
}
