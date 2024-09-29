using System.ComponentModel.DataAnnotations.Schema;
using ChatService.Domain.Entities.Accounts;
using ChatService.Domain.Entities.Messages;

namespace ChatService.Domain.Entities.Channels;

[Table("Channels")]
public partial class Channel : BaseEntity, ISoftDelete
{
    public Channel(string type)
    {
        Type = type;
    }

    public string? Name { get; set; }
    public string Type { get; private set; }
    public DateTime LastActivity { get; private set; } = DateTime.Now;
    public ICollection<Account> Accounts { get; private set; } = [];
    public ICollection<Message> Messages { get; private set; } = [];
    public Account? Owner { get; private set; }
    public int? OwnerId { get; private set; }
    public string? Image { get; set; }
    public bool IsDeleted { get; private set; } = false;
}
