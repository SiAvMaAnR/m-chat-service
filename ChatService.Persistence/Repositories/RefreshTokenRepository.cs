using ChatService.Domain.Entities.RefreshTokens;
using ChatService.Persistence.DBContext;
using ChatService.Persistence.Repositories.Common;

namespace ChatService.Persistence.Repositories;

public class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(EFContext dbContext)
        : base(dbContext) { }
}
