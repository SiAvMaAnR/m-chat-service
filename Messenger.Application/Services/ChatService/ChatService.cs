﻿using MessengerX.Application.Services.ChatService.Adapters;
using MessengerX.Application.Services.ChatService.Models;
using MessengerX.Application.Services.Common;
using MessengerX.Domain.Common;
using MessengerX.Domain.Entities.Messages;
using MessengerX.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.ChatService;

public class ChatService : BaseService, IChatService
{
    private readonly ChatBS _chatBS;

    public ChatService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IAppSettings appSettings,
        ChatBS chatBS
    )
        : base(unitOfWork, context, appSettings)
    {
        _chatBS = chatBS;
    }

    public async Task<ChatServiceMessagesResponse> MessagesAsync(ChatServiceMessagesRequest request)
    {
        IEnumerable<Message> messages = await _chatBS.MessagesAsync(
            request.ChannelId,
            request.SearchField
        );

        IOrderedEnumerable<Message> sortedMessages = messages.OrderByDescending(
            message => message.CreatedAt
        );

        PaginatorResponse<Message> paginatedData = sortedMessages.Pagination(request.Pagination);

        var adaptedMessages = paginatedData
            .Collection
            .Select(message => new ChatServiceMessageAdapter(message))
            .ToList();

        return new ChatServiceMessagesResponse()
        {
            Meta = paginatedData.Meta,
            Messages = adaptedMessages
        };
    }

    public async Task<ChatServiceSendMessageResponse> SendMessageAsync(
        ChatServiceSendMessageRequest request
    )
    {
        await Task.Run(() => { });
        throw new NotImplementedException();
    }
}
