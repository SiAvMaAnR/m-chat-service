namespace Chat.Application.Services.ChatService.Models;

public class ChatServiceCreateAIMessageRequest
{
    public int? OriginalMessageId { get; set; }
    public required int ChannelId { get; set; }
    public required string Message { get; set; }
}
