using System.ComponentModel.DataAnnotations;
using Chat.Domain.Shared.Constants.Validation;

namespace Chat.WebApi.Controllers.Models.User;

public class UserControllerUpdateInfoRequest
{
    [MaxLength(MaxLength.Login)]
    public required string Login { get; set; }
    public DateOnly? Birthday { get; set; }
}
