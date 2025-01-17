﻿namespace Chat.Application.Services.AccountService.Models;

public class AccountServiceAccountByEmailResponse
{
    public required int Id { get; set; }
    public required string Login { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public bool? IsBanned { get; set; }
}
