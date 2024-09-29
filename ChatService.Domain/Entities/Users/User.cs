using ChatService.Domain.Entities.Accounts;
using ChatService.Domain.Shared.Constants.Common;

namespace ChatService.Domain.Entities.Users;

public partial class User : Account
{
    public User(string email, string login, byte[] passwordHash, byte[] passwordSalt)
        : base(email, login, passwordHash, passwordSalt)
    {
        Role = AccountRole.User;
    }

    public DateOnly? Birthday { get; set; }
    public bool IsBanned { get; set; } = false;
}
