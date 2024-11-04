using Chat.Domain.Shared.Constants.Common;

namespace Chat.Domain.Entities.Accounts.AIBots;

public partial class AIBot : Account
{
    public AIBot(string email, string login, byte[] passwordHash, byte[] passwordSalt)
        : base(email, login, passwordHash, passwordSalt)
    {
        Role = AccountRole.AIBot;
    }
}
