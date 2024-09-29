namespace ChatService.Application.Services.ChatService.Models;

public class ChatServiceSendMessageRequest
{
    public int ChannelId { get; set; }
    public required string Message { get; set; }
    public IEnumerable<string> Attachments { get; set; } = [];
}
