using Chat.Domain.Entities.Accounts;
using Chat.Domain.Entities.Users;

namespace Chat.WebApi.RMQServices;

public partial class AccountsRMQService
{
    private static AdaptedAccount? AccountAdapter(Account? account)
    {
        return account != null
            ? new AdaptedAccount()
            {
                Id = account.Id,
                Email = account.Email,
                Login = account.Login,
                Role = account.Role,
                IsBanned = (account as User)?.IsBanned,
                PasswordHash = account.PasswordHash,
                PasswordSalt = account.PasswordSalt,
            }
            : null;
    }
}

internal class AdaptedAccount
{
    public required int Id { get; set; }
    public required string Login { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public bool? IsBanned { get; set; }
}
