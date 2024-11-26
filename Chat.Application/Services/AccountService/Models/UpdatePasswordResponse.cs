using Chat.Domain.Shared.Models;

namespace Chat.Application.Services.AccountService.Models;

public class AccountServiceUpdatePasswordResponse
{
    public required Password Password { get; set; }
}
