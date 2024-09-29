using Chat.Application.Services.ChatService.Models;
using Chat.Application.Services.Common;

namespace Chat.Application.Services.ChatService;

public interface IChatService : IBaseService
{
    Task<ChatServiceSendMessageResponse> SendMessageAsync(ChatServiceSendMessageRequest request);
    Task<ChatServiceReadMessageResponse> ReadMessageAsync(ChatServiceReadMessageRequest request);
    Task<ChatServiceMessagesResponse> MessagesAsync(ChatServiceMessagesRequest request);
    Task<ChatServiceUploadAttachmentResponse> UploadAttachmentAsync(
        ChatServiceUploadAttachmentRequest request
    );
    Task<ChatServiceRemoveAttachmentResponse> RemoveAttachmentAsync(
        ChatServiceRemoveAttachmentRequest request
    );
    Task<ChatServiceLoadAttachmentResponse> LoadAttachmentAsync(
        ChatServiceLoadAttachmentRequest request
    );
    Task<ChatServicePreviewAttachmentsResponse> PreviewAttachmentsAsync(
        ChatServicePreviewAttachmentsRequest request
    );
}
