using System.Text.Json;
using Chat.Application.Services.ChatService;
using Chat.Application.Services.ChatService.Models;
using Chat.Domain.Exceptions;
using Chat.Infrastructure.RabbitMQ;
using Chat.WebApi.Hubs;
using Chat.WebApi.Hubs.Common;
using Microsoft.AspNetCore.SignalR;

namespace Chat.WebApi.RMQListeners.Chat;

public partial class ChatRMQService : RMQService
{
    private readonly string _queueName = RMQ.Queue.Chat;
    private readonly IHubContext<ChatHub> _chatHub;

    public ChatRMQService(
        IRabbitMQConsumer consumer,
        IRabbitMQProducer producer,
        IServiceScopeFactory serviceScopeFactory,
        ILogger<ChatRMQService> logger,
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

        ChatServiceReadMessageResponse readMessageResponse = await chatService.ReadMessageAsync(
            new ChatServiceReadMessageRequest()
            {
                ChannelId = data.ChannelId,
                MessageId = sendMessageResponse.Message.Id,
                IsAIBot = true
            }
        );

        await _chatHub
            .Clients
            .Users(readMessageResponse.UserIds)
            .SendAsync(ChatHubMethod.ReadMessageResponse, readMessageResponse.ReadMessageIds);

        await _chatHub
            .Clients
            .Users(sendMessageResponse.UserIds)
            .SendAsync(ChatHubMethod.SendMessageResponse, sendMessageResponse.Message);
    }

    protected override Task RunAsync(CancellationToken stoppingToken)
    {
        _consumer.AddListener(
            _queueName,
            async (_, deliverEventData) =>
            {
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
