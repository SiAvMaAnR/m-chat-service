using System.ComponentModel.DataAnnotations.Schema;
using Messenger.Domain.Entities.Messages;

namespace Messenger.Domain.Entities.Attachments;

[Table("Attachments")]
public partial class Attachment : BaseEntity, ISoftDelete
{
    public Attachment(string content, string type)
    {
        Content = content;
        Type = type;
    }

    public string Content { get; private set; }
    public string Type { get; private set; }
    public bool IsDeleted { get; private set; } = false;
    public Message? Message { get; private set; }
    public int? MessageId { get; private set; }
}
