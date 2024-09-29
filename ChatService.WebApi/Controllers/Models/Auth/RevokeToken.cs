using System.ComponentModel.DataAnnotations;
using ChatService.Domain.Shared.Constants.Validation;

namespace ChatService.WebApi.Controllers.Models.Auth;

public class AuthControllerRevokeTokenRequest
{
    [MaxLength(MaxLength.RefreshToken)]
    public required string RefreshToken { get; set; }
}
