using System.Text.Json;
using Chat.Application.Services.ChatService;
using Chat.Application.Services.ChatService.Models;
using Chat.Domain.Exceptions;
using Chat.Infrastructure.RabbitMQ;
using Chat.WebApi.Hubs;
using Chat.WebApi.Hubs.Common;
using Microsoft.AspNetCore.SignalR;

namespace Chat.WebApi.RMQListeners.AI;

public partial class AIRMQService : RMQService
{
    private readonly string _queueName = RMQ.Queue.Chat;
    private readonly IHubContext<ChatHub> _chatHub;

    public AIRMQService(
        IRabbitMQConsumer consumer,
        IRabbitMQProducer producer,
        IServiceScopeFactory serviceScopeFactory,
        ILogger<AIRMQService> logger,
        IHubContext<ChatHub> chatHub
    )
        : base(consumer, producer, serviceScopeFactory, logger)
    {
        _chatHub = chatHub;
    }

    private async Task SendMessageAsync(SendMessageData data, IChatService chatService)
    {
        ChatServiceCreateAIMessageResponse sendMessageResponse =
            await chatService.CreateAIMessageAsync(
                new ChatServiceCreateAIMessageRequest()
                {
                    ChannelId = data.ChannelId,
                    Message = data.Message
                }
            );

        await _chatHub
            .Clients
            .Users(sendMessageResponse.UserIds)
            .SendAsync(ChatHubMethod.SendMessageResponse, sendMessageResponse.Message);
    }

    protected override Task RunAsync(CancellationToken stoppingToken)
    {
        _consumer.AddListener(
            _queueName,
            async (_, args) =>
            {
                DeliverEventData deliverEventData = RabbitMQBase.GetDeliverEventData(args);

                using IServiceScope scope = _serviceScopeFactory.CreateScope();

                RMQResponse<JsonElement> deserializedResponse =
                    deliverEventData.DeserializedResponse;

                IChatService chatService = scope.ServiceProvider.GetRequiredService<IChatService>();

                Task task = deserializedResponse.Pattern switch
                {
                    RMQ.AIQueuePattern.CreateMessage
                        => SendMessageAsync(
                            JsonSerializer.Deserialize<SendMessageData>(
                                deserializedResponse.Data,
                                deliverEventData.SerializerOptions
                            )!,
                            chatService
                        ),
                    _ => throw new OperationNotAllowedException("Message pattern not found")
                };

                await task;
            }
        );

        return Task.CompletedTask;
    }
}
