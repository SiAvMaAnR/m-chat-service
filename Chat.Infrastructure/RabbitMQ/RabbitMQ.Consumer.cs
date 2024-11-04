using Chat.Domain.Common;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Chat.Infrastructure.RabbitMQ;

public class RabbitMQConsumer : RabbitMQBase, IRabbitMQConsumer
{
    private readonly EventingBasicConsumer _consumer;
    private readonly ILogger<RabbitMQConsumer> _logger;

    public RabbitMQConsumer(IAppSettings appSettings, ILogger<RabbitMQConsumer> logger)
        : base(appSettings)
    {
        _logger = logger;
        _consumer = new EventingBasicConsumer(_channel);
    }

    public void AddListener(string queueName, Func<object?, BasicDeliverEventArgs, Task> handler)
    {
        CreateQueue(queueName);

        _consumer.Received += async (sender, args) =>
        {
            try
            {
                if (args.RoutingKey == queueName)
                {
                    await handler(sender, args);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "RabbitMQ listener: {Message}", ex.Message);
            }
        };

        _channel.BasicConsume(
            queue: queueName,
            autoAck: true,
            consumer: _consumer,
            consumerTag: Guid.NewGuid().ToString()
        );
    }

    public void RemoveListener(EventHandler<BasicDeliverEventArgs> handler)
    {
        _consumer.Received -= handler;
    }
}
