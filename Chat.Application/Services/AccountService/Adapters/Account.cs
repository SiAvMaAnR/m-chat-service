using Chat.Application.Services.AccountService.Models;
using Chat.Domain.Entities.Accounts;
using Chat.Domain.Entities.Accounts.Users;
using Chat.Persistence.Extensions;

namespace Chat.Application.Services.AccountService.Adapters;

public class AccountServiceAccountAdapter : AccountServiceAccountResponseData
{
    private readonly string? _imagePath;

    public AccountServiceAccountAdapter(Account account)
    {
        _imagePath = account.Image;

        Id = account.Id;
        Login = account.Login;
        Email = account.Email;
        Role = account.Role;
        IsBanned = (account as User)?.IsBanned;
        ActivityStatus = account.ActivityStatus;
        LastOnlineAt = account.LastOnlineAt;
    }

    public async Task LoadImageAsync()
    {
        Image = await FileManager.ReadToBytesAsync(_imagePath);
    }
}
