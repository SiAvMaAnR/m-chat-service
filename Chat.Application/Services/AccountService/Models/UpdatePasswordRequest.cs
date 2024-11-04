using Chat.Domain.Shared.Models;

namespace Chat.Application.Services.AccountService.Models;

public class AccountServiceUpdatePasswordRequest
{
    public required int AccountId { get; set; }
    public required Password Password { get; set; }
}
