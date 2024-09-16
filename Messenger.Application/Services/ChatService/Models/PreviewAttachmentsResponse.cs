namespace Messenger.Application.Services.ChatService.Models;

public class PreviewAttachmentResponse
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public string? UniqueId { get; set; }
}

public class ChatServicePreviewAttachmentsResponse
{
    public IEnumerable<PreviewAttachmentResponse> PreviewAttachments { get; set; } = [];
}
