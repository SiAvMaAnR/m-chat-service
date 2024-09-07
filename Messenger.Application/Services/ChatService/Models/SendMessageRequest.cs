namespace Messenger.Application.Services.ChatService.Models;

public class ChatServiceSendMessageRequest
{
    public int ChannelId { get; set; }
    public required string Message { get; set; }
    public IEnumerable<AttachmentRequest> Attachments { get; set; } = [];
}

public class AttachmentRequest
{
    public required string Content { get; set; }
    public required string Type { get; set; }
}
