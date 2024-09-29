using ChatService.Domain.Shared.Models;

namespace ChatService.Application.Services.ChatService.Models;

public class ChatServiceMessagesRequest
{
    public int ChannelId { get; set; }
    public string? SearchField { get; set; }
    public Pagination? Pagination { get; set; }
}
