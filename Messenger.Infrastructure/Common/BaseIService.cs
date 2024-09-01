using Messenger.Domain.Common;
using Messenger.Infrastructure.RabbitMQ;

namespace Messenger.Infrastructure.Services.Common;

public abstract class BaseIService(IAppSettings appSettings, IRabbitMQProducer rabbitMQProducer)
{
    protected readonly IAppSettings _appSettings = appSettings;
    protected readonly IRabbitMQProducer _rabbitMQProducer = rabbitMQProducer;
}
