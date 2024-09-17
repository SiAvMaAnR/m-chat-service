using Messenger.Application.Services.ChatService.Models;
using Messenger.Domain.Entities.Attachments;

namespace Messenger.Application.Services.ChatService.Adapters;

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
