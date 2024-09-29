using Chat.Domain.Entities.RefreshTokens;
using Chat.Domain.Specification;

namespace Chat.Domain.Entities.Accounts;

public class RefreshTokenByTokenSpec : Specification<RefreshToken>
{
    public RefreshTokenByTokenSpec(string? refreshToken)
        : base((token) => token.Token == refreshToken) { }
}
