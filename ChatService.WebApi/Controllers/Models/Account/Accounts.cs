using ChatService.Domain.Shared.Models;

namespace ChatService.WebApi.Controllers.Models.Account;

public class AccountControllerAccountsRequest
{
    public Pagination? Pagination { get; set; }

    public bool IsLoadImage { get; set; }
    public string? SearchField { get; set; }
}
