using Messenger.Application.Services.ChatService.Models;

namespace Messenger.WebApi.Hubs.Models.Chat;

public class ChatHubSendMessageRequest
{
    public required int ChannelId { get; set; }
    public required string Message { get; set; }
    public IEnumerable<AttachmentRequest> Attachments { get; set; } = [];
}
