using ChatService.Domain.Entities.Accounts;
using ChatService.Persistence.DBContext;
using ChatService.Persistence.Repositories.Common;

namespace ChatService.Persistence.Repositories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(EFContext dbContext)
        : base(dbContext) { }
}
