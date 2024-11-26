using Chat.Infrastructure.RabbitMQ;

namespace Chat.WebApi.RMQListeners;

public abstract class RMQService : BackgroundService
{
    protected readonly IRabbitMQConsumer _consumer;
    protected readonly IRabbitMQProducer _producer;
    protected readonly ILogger<RMQService> _logger;
    protected readonly IServiceScopeFactory _serviceScopeFactory;

    protected RMQService(
        IRabbitMQConsumer consumer,
        IRabbitMQProducer producer,
        IServiceScopeFactory serviceScopeFactory,
        ILogger<RMQService> logger
    )
    {
        _consumer = consumer;
        _producer = producer;
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
    }

    protected abstract Task RunAsync(CancellationToken stoppingToken);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            await RunAsync(stoppingToken);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "RMQ Receiver exception: {Message}", exception.Message);
        }
    }
}
