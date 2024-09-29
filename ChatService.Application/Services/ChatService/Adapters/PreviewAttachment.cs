using ChatService.Application.Services.ChatService.Models;
using ChatService.Domain.Entities.Attachments;

namespace ChatService.Application.Services.ChatService.Adapters;

public class ChatServicePreviewAttachmentAdapter : PreviewAttachmentResponse
{
    public ChatServicePreviewAttachmentAdapter(Attachment attachment)
    {
        Id = attachment.Id;
        Type = attachment.Type;
        UniqueId = attachment.UniqueId;
        Name = attachment.Name;
        Size = attachment.Size;
    }
}
