namespace Chat.Application.Services.AccountService.Models;

public class AccountServiceAccountByIdResponse
{
    public required int Id { get; set; }
    public required string Login { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }
    public bool? IsBanned { get; set; }
}

public class AccountServiceExtendedAccountByIdResponse : AccountServiceAccountByIdResponse
{
    public string? ActivityStatus { get; set; }
    public DateTime? LastOnlineAt { get; set; }
}

public class AccountServiceFullAccountByIdResponse : AccountServiceExtendedAccountByIdResponse
{
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
}
