using System.Text.Json;
using Chat.Application.Services.AccountService;
using Chat.Application.Services.AccountService.Models;
using Chat.Domain.Exceptions;
using Chat.Infrastructure.RabbitMQ;
using RabbitMQ.Client;

namespace Chat.WebApi.RMQListeners.Accounts;

public partial class AccountsRMQService : RMQService
{
    private readonly string _queueName = RMQ.Queue.Accounts;

    public AccountsRMQService(
        IRabbitMQConsumer consumer,
        IRabbitMQProducer producer,
        IServiceScopeFactory serviceScopeFactory,
        ILogger<AccountsRMQService> logger
    )
        : base(consumer, producer, serviceScopeFactory, logger) { }

    private async Task GetByEmailAsync(
        IBasicProperties basicProperties,
        GetByEmailData args,
        IAccountService accountService
    )
    {
        AccountServiceAccountByEmailResponse response = await accountService.GetAccountByEmailAsync(
            new AccountServiceAccountByEmailRequest() { Email = args.Email }
        );

        _producer.Emit(
            basicProperties.ReplyTo,
            RMQ.AccountsQueuePattern.GetByEmail,
            response,
            basicProperties.CorrelationId
        );
    }

    private async Task GetByIdAsync(
        IBasicProperties basicProperties,
        GetByIdData args,
        IAccountService accountService
    )
    {
        AccountServiceAccountByIdResponse response = await accountService.GetAccountByIdAsync(
            new AccountServiceAccountByIdRequest() { AccountId = args.AccountId }
        );

        _producer.Emit(
            basicProperties.ReplyTo,
            RMQ.AccountsQueuePattern.GetById,
            response,
            basicProperties.CorrelationId
        );
    }

    private async Task UpdatePasswordAsync(
        IBasicProperties basicProperties,
        UpdatePasswordData args,
        IAccountService accountService
    )
    {
        AccountServiceUpdatePasswordResponse response = await accountService.UpdatePasswordAsync(
            new AccountServiceUpdatePasswordRequest()
            {
                AccountId = args.AccountId,
                Password = args.Password
            }
        );

        _producer.Emit(
            basicProperties.ReplyTo,
            RMQ.AccountsQueuePattern.UpdatePassword,
            response.Password,
            basicProperties.CorrelationId
        );
    }

    protected override Task RunAsync(CancellationToken stoppingToken)
    {
        _consumer.AddListener(
            _queueName,
            async (_, args) =>
            {
                DeliverEventData deliverEventData = RabbitMQBase.GetDeliverEventData(args);

                using IServiceScope scope = _serviceScopeFactory.CreateScope();

                IAccountService accountService = scope
                    .ServiceProvider
                    .GetRequiredService<IAccountService>();

                RMQResponse<JsonElement> deserializedResponse =
                    deliverEventData.DeserializedResponse;

                Task task = deserializedResponse.Pattern switch
                {
                    RMQ.AccountsQueuePattern.GetByEmail
                        => GetByEmailAsync(
                            args.BasicProperties,
                            JsonSerializer.Deserialize<GetByEmailData>(
                                deserializedResponse.Data,
                                deliverEventData.SerializerOptions
                            )!,
                            accountService
                        ),
                    RMQ.AccountsQueuePattern.GetById
                        => GetByIdAsync(
                            args.BasicProperties,
                            JsonSerializer.Deserialize<GetByIdData>(
                                deserializedResponse.Data,
                                deliverEventData.SerializerOptions
                            )!,
                            accountService
                        ),
                    RMQ.AccountsQueuePattern.UpdatePassword
                        => UpdatePasswordAsync(
                            args.BasicProperties,
                            JsonSerializer.Deserialize<UpdatePasswordData>(
                                deserializedResponse.Data,
                                deliverEventData.SerializerOptions
                            )!,
                            accountService
                        ),
                    _ => throw new OperationNotAllowedException("Message pattern not found")
                };

                await task;
            }
        );

        return Task.CompletedTask;
    }
}
