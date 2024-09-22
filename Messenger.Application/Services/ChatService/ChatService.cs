using Messenger.Application.Services.ChatService.Adapters;
using Messenger.Application.Services.ChatService.Extensions;
using Messenger.Application.Services.ChatService.Models;
using Messenger.Application.Services.Common;
using Messenger.Domain.Common;
using Messenger.Domain.Entities.Accounts;
using Messenger.Domain.Entities.Attachments;
using Messenger.Domain.Entities.Messages;
using Messenger.Domain.Exceptions;
using Messenger.Domain.Services;
using Messenger.Persistence.Extensions;
using Microsoft.AspNetCore.Http;

namespace Messenger.Application.Services.ChatService;

public class ChatService : BaseService, IChatService
{
    private readonly ChatBS _chatBS;
    private readonly AttachmentBS _attachmentBS;

    public ChatService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IAppSettings appSettings,
        ChatBS chatBS,
        AttachmentBS attachmentBS
    )
        : base(unitOfWork, context, appSettings)
    {
        _chatBS = chatBS;
        _attachmentBS = attachmentBS;
    }

    public async Task<ChatServiceMessagesResponse> MessagesAsync(ChatServiceMessagesRequest request)
    {
        IEnumerable<Message> messages = await _chatBS.MessagesAsync(
            request.ChannelId,
            request.SearchField
        );

        PaginatorResponse<Message> paginatedData = messages.Pagination(request.Pagination);

        IEnumerable<ChatServiceMessageAdapter> adaptedMessages = paginatedData
            .Collection
            .Select(message => new ChatServiceMessageAdapter(message));

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
        Message message = await _chatBS.AddMessageAsync(
            UserId,
            request.ChannelId,
            request.Message,
            request.Attachments
        );

        IEnumerable<string> userIds = await _chatBS.GetUserIdsByChannelIdAsync(
            UserId,
            request.ChannelId
        );

        return new ChatServiceSendMessageResponse()
        {
            UserIds = userIds,
            Message = new ChatServiceMessageAdapter(message)
        };
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

    public async Task<ChatServiceUploadAttachmentResponse> UploadAttachmentAsync(
        ChatServiceUploadAttachmentRequest request
    )
    {
        Attachment attachment = await ProcessAttachment.CreateFileAsync(request, _appSettings);

        attachment.SetChannel(request.ChannelId);
        attachment.SetOwner(UserId);

        await _attachmentBS.CreateAttachmentAsync(attachment);

        return new ChatServiceUploadAttachmentResponse() { AttachmentId = attachment.Id };
    }

    public async Task<ChatServiceLoadAttachmentResponse> LoadAttachmentAsync(
        ChatServiceLoadAttachmentRequest request
    )
    {
        Attachment? attachment =
            await _attachmentBS.GetAttachmentByIdAsync(request.AttachmentId)
            ?? throw new NotExistsException("Attachment not found");

        ICollection<Account>? accounts = attachment.Message?.Channel?.Accounts ?? [];

        if (attachment.OwnerId != UserId && !accounts.Any(account => account.Id == UserId))
            throw new OperationNotAllowedException();

        byte[] contentBytes = await FileManager.ReadToBytesAsync(attachment.Content) ?? [];

        return new ChatServiceLoadAttachmentResponse()
        {
            Id = attachment.Id,
            Content = contentBytes,
            Type = attachment.Type,
            Name = attachment.Name,
            Size = attachment.Size
        };
    }

    public async Task<ChatServiceRemoveAttachmentResponse> RemoveAttachmentAsync(
        ChatServiceRemoveAttachmentRequest request
    )
    {
        Attachment? attachment =
            await _attachmentBS.GetAttachmentByUniqueIdAsync(request.UniqueId)
            ?? throw new NotExistsException("Attachment not found");

        ProcessAttachment.RemoveFile(attachment);
        await _attachmentBS.RemoveAttachmentAsync(attachment);

        return new ChatServiceRemoveAttachmentResponse() { AttachmentId = attachment.Id };
    }

    public async Task<ChatServicePreviewAttachmentsResponse> PreviewAttachmentsAsync(
        ChatServicePreviewAttachmentsRequest request
    )
    {
        IEnumerable<Attachment> previewAttachments = await _attachmentBS.GetPreviewAttachmentsAsync(
            request.ChannelId,
            UserId
        );

        return new ChatServicePreviewAttachmentsResponse()
        {
            PreviewAttachments = previewAttachments.Select(
                attachment => new ChatServicePreviewAttachmentAdapter(attachment)
            )
        };
    }
}
