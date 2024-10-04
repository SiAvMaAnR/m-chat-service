using Chat.Domain.Specification;

namespace Chat.Domain.Entities.Attachments;

public class AttachmentByUniqueIdSpec : Specification<Attachment>
{
    public AttachmentByUniqueIdSpec(string uniqueId)
        : base((attachment) => attachment.UniqueId == uniqueId)
    {
        AddInclude("Message.Channel.Accounts");
    }
}

public class AttachmentByIdSpec : Specification<Attachment>
{
    public AttachmentByIdSpec(int id)
        : base((attachment) => attachment.Id == id)
    {
        AddInclude("Message.Channel.Accounts");
    }
}

public class AttachmentsByUniqueIdsSpec : Specification<Attachment>
{
    public AttachmentsByUniqueIdsSpec(IEnumerable<string> attachmentUniqueIds)
        : base((attachment) => attachmentUniqueIds.Contains(attachment.UniqueId)) { }
}

public class PreviewAttachmentsSpec : Specification<Attachment>
{
    public PreviewAttachmentsSpec(int channelId, int ownerId)
        : base(
            (attachment) =>
                attachment.MessageId == null
                && attachment.ChannelId == channelId
                && attachment.OwnerId == ownerId
        )
    { }
}
