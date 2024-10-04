using Chat.Infrastructure.RabbitMQ;

namespace Chat.WebApi.RMQServices;

public abstract class RMQService : BackgroundService
{
    protected readonly IRabbitMQConsumer _consumer;
    protected readonly IRabbitMQProducer _producer;

    protected RMQService(IRabbitMQConsumer consumer, IRabbitMQProducer producer)
    {
        _consumer = consumer;
        _producer = producer;
    }
}
