using ChatService.Domain.Shared.Models;

namespace ChatService.Application.Services.AccountService.Models;

public class AccountServiceAccountsRequest
{
    public Pagination? Pagination { get; set; }
    public bool IsLoadImage { get; set; }
    public string? SearchField { get; set; }
}
