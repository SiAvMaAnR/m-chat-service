namespace Messenger.Domain.Entities.Attachments;

public partial class Attachment : IAggregateRoot
{
    public void Delete()
    {
        IsDeleted = true;
    }

    public void SetMessage(int messageId)
    {
        MessageId = messageId;
    }

    public void SetOwner(int ownerId)
    {
        OwnerId = ownerId;
    }

    public void SetChannel(int channelId)
    {
        ChannelId = channelId;
    }
}
