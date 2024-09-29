using System.ComponentModel.DataAnnotations;
using Chat.Domain.Shared.Constants.Validation;

namespace Chat.WebApi.Controllers.Models.Auth;

public class AuthControllerResetPasswordRequest
{
    [MaxLength(MaxLength.ResetToken)]
    public required string ResetToken { get; set; }

    [MaxLength(MaxLength.Password)]
    public required string Password { get; set; }
}
