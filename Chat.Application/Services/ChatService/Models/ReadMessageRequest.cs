namespace Chat.Application.Services.ChatService.Models;

public class ChatServiceReadMessageRequest
{
    public required int ChannelId { get; set; }
    public required int MessageId { get; set; }
    public bool IsAIBot { get; set; } = false;
}
