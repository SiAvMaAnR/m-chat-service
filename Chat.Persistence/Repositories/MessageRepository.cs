using Chat.Domain.Entities.Messages;
using Chat.Persistence.DBContext;
using Chat.Persistence.Repositories.Common;

namespace Chat.Persistence.Repositories;

public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    public MessageRepository(EFContext dbContext)
        : base(dbContext) { }
}
