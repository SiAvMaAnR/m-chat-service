namespace Messenger.Application.Services.ChatService.Models;

public class ChatServiceLoadAttachmentResponse
{
    public required int Id { get; set; }
    public byte[]? Content { get; set; } = null;
    public required string Type { get; set; }
}
