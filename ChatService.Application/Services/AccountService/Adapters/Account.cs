using ChatService.Application.Services.AccountService.Models;
using ChatService.Domain.Entities.Accounts;
using ChatService.Domain.Entities.Users;
using ChatService.Persistence.Extensions;

namespace ChatService.Application.Services.AccountService.Adapters;

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
