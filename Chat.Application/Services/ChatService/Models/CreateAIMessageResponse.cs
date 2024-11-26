namespace Chat.Application.Services.ChatService.Models;

public class ChatServiceCreateAIMessageResponse
{
    public IEnumerable<string> UserIds { get; set; } = [];
    public required ChatServiceMessageResponseData Message { get; set; }
}
