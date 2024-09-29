using ChatService.Domain.Entities.Channels;
using ChatService.Persistence.DBContext;
using ChatService.Persistence.Repositories.Common;

namespace ChatService.Persistence.Repositories;

public class ChannelRepository : BaseRepository<Channel>, IChannelRepository
{
    public ChannelRepository(EFContext dbContext)
        : base(dbContext) { }
}
