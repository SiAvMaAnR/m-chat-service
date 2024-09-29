using ChatService.Domain.Entities.Users;
using ChatService.Persistence.DBContext;
using ChatService.Persistence.Repositories.Common;

namespace ChatService.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(EFContext dbContext)
        : base(dbContext) { }
}
