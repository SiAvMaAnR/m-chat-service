using Chat.Domain.Entities.Accounts.Users;
using Chat.Persistence.DBContext;
using Chat.Persistence.Repositories.Common;

namespace Chat.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(EFContext dbContext)
        : base(dbContext) { }
}
