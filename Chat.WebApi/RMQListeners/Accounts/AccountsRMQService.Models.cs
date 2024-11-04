using Chat.Domain.Shared.Models;

namespace Chat.WebApi.RMQListeners.Accounts;

public partial class AccountsRMQService
{
    public class GetByEmailData
    {
        public required string Email { get; set; }
    }

    public class GetByIdData
    {
        public required int AccountId { get; set; }
    }

    public class UpdatePasswordData
    {
        public required int AccountId { get; set; }
        public required Password Password { get; set; }
    }
}
