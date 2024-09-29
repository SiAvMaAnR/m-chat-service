using Chat.Domain.Entities.Accounts;
using Chat.Persistence.DBContext;
using Chat.Persistence.Repositories.Common;

namespace Chat.Persistence.Repositories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(EFContext dbContext)
        : base(dbContext) { }
}
