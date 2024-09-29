using ChatService.Domain.Entities.Accounts;
using ChatService.Domain.Shared.Constants.Common;

namespace ChatService.Domain.Entities.Admins;

public partial class Admin : Account
{
    public Admin(string email, string login, byte[] passwordHash, byte[] passwordSalt)
        : base(email, login, passwordHash, passwordSalt)
    {
        Role = AccountRole.Admin;
    }

    public bool IsActive { get; private set; } = true;
}
