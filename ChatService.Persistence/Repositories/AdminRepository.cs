using ChatService.Domain.Entities.Admins;
using ChatService.Persistence.DBContext;
using ChatService.Persistence.Repositories.Common;

namespace ChatService.Persistence.Repositories;

public class AdminRepository : BaseRepository<Admin>, IAdminRepository
{
    public AdminRepository(EFContext dbContext)
        : base(dbContext) { }
}
