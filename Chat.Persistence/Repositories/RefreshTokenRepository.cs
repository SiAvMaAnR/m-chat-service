using Chat.Domain.Entities.RefreshTokens;
using Chat.Persistence.DBContext;
using Chat.Persistence.Repositories.Common;

namespace Chat.Persistence.Repositories;

public class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(EFContext dbContext)
        : base(dbContext) { }
}
