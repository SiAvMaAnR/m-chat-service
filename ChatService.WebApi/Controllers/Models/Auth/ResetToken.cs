using System.ComponentModel.DataAnnotations;
using ChatService.Domain.Shared.Constants.Validation;

namespace ChatService.WebApi.Controllers.Models.Auth;

public class AuthControllerResetTokenRequest
{
    [EmailAddress, MaxLength(MaxLength.Email)]
    public required string Email { get; set; }
}
