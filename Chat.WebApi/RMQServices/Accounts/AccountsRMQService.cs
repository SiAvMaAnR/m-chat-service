using System.Text;
using System.Text.Json;
using Chat.Domain.Entities.Accounts;
using Chat.Domain.Exceptions;
using Chat.Domain.Services;
using Chat.Infrastructure.RabbitMQ;
using RabbitMQ.Client;

namespace Chat.WebApi.RMQServices;

public partial class AccountsRMQService : RMQService
{
    private readonly string _queueName = RMQ.Queue.Accounts;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public AccountsRMQService(
        IRabbitMQConsumer consumer,
        IRabbitMQProducer producer,
        IServiceScopeFactory serviceScopeFactory
    )
        : base(consumer, producer)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    private async Task GetByEmailAsync(
        IBasicProperties basicProperties,
        GetByEmailData data,
        AccountBS accountBS
    )
    {
        Account? account = await accountBS.GetAccountByEmailAsync(data.Email);

        _producer.SendReply(
            basicProperties.ReplyTo,
            basicProperties.CorrelationId,
            RMQ.AccountsQueuePattern.GetByEmail,
            AccountAdapter(account)
        );
    }

    private async Task GetByIdAsync(
        IBasicProperties basicProperties,
        GetByIdData data,
        AccountBS accountBS
    )
    {
        Account? account = await accountBS.GetAccountByIdAsync(data.AccountId);

        _producer.SendReply(
            basicProperties.ReplyTo,
            basicProperties.CorrelationId,
            RMQ.AccountsQueuePattern.GetById,
            AccountAdapter(account)
        );
    }

    private async Task UpdatePasswordAsync(
        IBasicProperties basicProperties,
        UpdatePasswordData data,
        AccountBS accountBS
    )
    {
        Account account =
            await accountBS.GetAccountByIdAsync(data.AccountId)
            ?? throw new NotExistsException("Account not found");

        await accountBS.UpdatePasswordAsync(account, data.Password);

        _producer.SendReply(
            basicProperties.ReplyTo,
            basicProperties.CorrelationId,
            RMQ.AccountsQueuePattern.UpdatePassword,
            data.Password
        );
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _consumer.AddListener(
            _queueName,
            async (_, args) =>
            {
                byte[] body = args.Body.ToArray();
                string bodyJson = Encoding.UTF8.GetString(body);
                JsonSerializerOptions serializerOptions = RabbitMQBase.JsonSerializerOptions;

                RMQResponse<JsonElement> result =
                    JsonSerializer.Deserialize<RMQResponse<JsonElement>>(
                        bodyJson,
                        serializerOptions
                    ) ?? throw new IncorrectDataException("Failed to deserialize json");

                string replyQueue = args.BasicProperties.ReplyTo;
                string correlationId = args.BasicProperties.CorrelationId;

                using IServiceScope scope = _serviceScopeFactory.CreateScope();

                AccountBS accountBS = scope.ServiceProvider.GetRequiredService<AccountBS>();

                Task task = result.Pattern switch
                {
                    RMQ.AccountsQueuePattern.GetByEmail
                        => GetByEmailAsync(
                            args.BasicProperties,
                            JsonSerializer.Deserialize<GetByEmailData>(
                                result.Data,
                                serializerOptions
                            )!,
                            accountBS
                        ),
                    RMQ.AccountsQueuePattern.GetById
                        => GetByIdAsync(
                            args.BasicProperties,
                            JsonSerializer.Deserialize<GetByIdData>(
                                result.Data,
                                serializerOptions
                            )!,
                            accountBS
                        ),
                    RMQ.AccountsQueuePattern.UpdatePassword
                        => UpdatePasswordAsync(
                            args.BasicProperties,
                            JsonSerializer.Deserialize<UpdatePasswordData>(
                                result.Data,
                                serializerOptions
                            )!,
                            accountBS
                        ),
                    _ => throw new OperationNotAllowedException("Message pattern not found")
                };

                await task;
            }
        );

        return Task.CompletedTask;
    }
}
