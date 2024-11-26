using Chat.Domain.Entities.Accounts.AIBots;
using Chat.Persistence.DBContext;
using Chat.Persistence.Repositories.Common;

namespace Chat.Persistence.Repositories;

public class AIBotRepository : BaseRepository<AIBot>, IAIBotRepository
{
    public AIBotRepository(EFContext dbContext)
        : base(dbContext) { }
}
