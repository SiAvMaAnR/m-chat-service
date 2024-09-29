using ChatService.Application.Services.ChatService.Models;
using ChatService.Application.Services.Common;

namespace ChatService.Application.Services.ChatService;

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
