using System.Diagnostics;
using Messenger.Application.Services.ChatService.Adapters;
using Messenger.Application.Services.ChatService.Extensions;
using Messenger.Application.Services.ChatService.Models;
using Messenger.Application.Services.Common;
using Messenger.Domain.Common;
using Messenger.Domain.Entities.Attachments;
using Messenger.Domain.Entities.Messages;
using Messenger.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace Messenger.Application.Services.ChatService;

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

        PaginatorResponse<Message> paginatedData = messages.Pagination(request.Pagination);

        IEnumerable<Task<ChatServiceMessageAdapter>> adaptedMessagesTasks = paginatedData
            .Collection
            .Select(message => new ChatServiceMessageAdapter(message).LoadAttachmentsAsync());

        ChatServiceMessageAdapter[] messagesResult = await Task.WhenAll(adaptedMessagesTasks);

        return new ChatServiceMessagesResponse()
        {
            Meta = paginatedData.Meta,
            Messages = messagesResult
        };
    }

    public async Task<ChatServiceSendMessageResponse> SendMessageAsync(
        ChatServiceSendMessageRequest request
    )
    {
        Attachment[] attachments = await request.Attachments.ProcessAttachmentsAsync(_appSettings);

        Message message = await _chatBS.AddMessageAsync(
            UserId,
            request.ChannelId,
            request.Message,
            attachments.ToList()
        );

        IEnumerable<string> userIds = await _chatBS.GetUserIdsByChannelIdAsync(
            UserId,
            request.ChannelId
        );

        var adaptedMessage = new ChatServiceMessageAdapter(message);

        await adaptedMessage.LoadAttachmentsAsync();

        return new ChatServiceSendMessageResponse() { UserIds = userIds, Message = adaptedMessage };
    }

    public async Task<ChatServiceReadMessageResponse> ReadMessageAsync(
        ChatServiceReadMessageRequest request
    )
    {
        IEnumerable<Message> readMessages = await _chatBS.ReadMessagesAsync(
            request.ChannelId,
            request.MessageId,
            UserId
        );

        IEnumerable<string> userIds = await _chatBS.GetUserIdsByChannelIdAsync(
            UserId,
            request.ChannelId
        );

        int unreadMessagesCount = await _chatBS.GetUnreadMessagesCountAsync(
            UserId,
            request.ChannelId
        );

        return new ChatServiceReadMessageResponse()
        {
            ReadMessageIds = readMessages.Select(message => message.Id),
            UserIds = userIds,
            UnreadMessagesCount = unreadMessagesCount
        };
    }
}
