using Chat.Domain.Entities.Accounts.Admins;
using Chat.Persistence.DBContext;
using Chat.Persistence.Repositories.Common;

namespace Chat.Persistence.Repositories;

public class AdminRepository : BaseRepository<Admin>, IAdminRepository
{
    public AdminRepository(EFContext dbContext)
        : base(dbContext) { }
}
