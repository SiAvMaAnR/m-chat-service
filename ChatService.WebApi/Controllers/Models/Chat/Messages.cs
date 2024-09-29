using ChatService.Domain.Shared.Models;

namespace ChatService.WebApi.Controllers.Models.Chat;

public class ChatControllerMessagesRequest
{
    public int ChannelId { get; set; }
    public string? SearchField { get; set; }
    public Pagination? Pagination { get; set; }
}
