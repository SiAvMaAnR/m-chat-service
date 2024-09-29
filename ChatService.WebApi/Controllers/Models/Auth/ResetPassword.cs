using System.ComponentModel.DataAnnotations;
using ChatService.Domain.Shared.Constants.Validation;

namespace ChatService.WebApi.Controllers.Models.Auth;

public class AuthControllerResetPasswordRequest
{
    [MaxLength(MaxLength.ResetToken)]
    public required string ResetToken { get; set; }

    [MaxLength(MaxLength.Password)]
    public required string Password { get; set; }
}
