using ChatService.Domain.Entities.RefreshTokens;
using ChatService.Domain.Specification;

namespace ChatService.Domain.Entities.Accounts;

public class RefreshTokenByTokenSpec : Specification<RefreshToken>
{
    public RefreshTokenByTokenSpec(string? refreshToken)
        : base((token) => token.Token == refreshToken) { }
}
