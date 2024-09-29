using System.ComponentModel.DataAnnotations;
using Chat.Domain.Shared.Constants.Validation;

namespace Chat.WebApi.Controllers.Models.Auth;

public class AuthControllerRevokeTokenRequest
{
    [MaxLength(MaxLength.RefreshToken)]
    public required string RefreshToken { get; set; }
}
