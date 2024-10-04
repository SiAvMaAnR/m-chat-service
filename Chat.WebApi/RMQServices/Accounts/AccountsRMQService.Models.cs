using System.Text.Json.Serialization;
using Chat.Domain.Shared.Models;

namespace Chat.WebApi.RMQServices;

public partial class AccountsRMQService
{
    public class GetByEmailData
    {
        [JsonPropertyName("email")]
        public required string Email { get; set; }
    }

    public class GetByIdData
    {
        [JsonPropertyName("accountId")]
        public required int AccountId { get; set; }
    }

    public class UpdatePasswordData
    {
        [JsonPropertyName("accountId")]
        public required int AccountId { get; set; }
        [JsonPropertyName("password")]
        public required Password Password { get; set; }
    }
}
