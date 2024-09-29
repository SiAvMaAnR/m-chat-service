using Chat.Domain.Entities.Accounts;
using Chat.Domain.Shared.Constants.Common;

namespace Chat.Domain.Entities.Admins;

public partial class Admin : Account
{
    public Admin(string email, string login, byte[] passwordHash, byte[] passwordSalt)
        : base(email, login, passwordHash, passwordSalt)
    {
        Role = AccountRole.Admin;
    }

    public bool IsActive { get; private set; } = true;
}
