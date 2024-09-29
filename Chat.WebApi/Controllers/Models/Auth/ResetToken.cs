using System.ComponentModel.DataAnnotations;
using Chat.Domain.Shared.Constants.Validation;

namespace Chat.WebApi.Controllers.Models.Auth;

public class AuthControllerResetTokenRequest
{
    [EmailAddress, MaxLength(MaxLength.Email)]
    public required string Email { get; set; }
}
