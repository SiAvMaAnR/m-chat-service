namespace Messenger.Application.Services.ChatService.Models;

public class ChatServiceUploadAttachmentRequest
{
    public required string UniqueId { get; set; }
    public required string Content { get; set; }
    public required string Type { get; set; }
    public required int ChannelId { get; set; }
}
