using System.ComponentModel.DataAnnotations;
using ChatService.Domain.Shared.Constants.Validation;

namespace ChatService.WebApi.Controllers.Models.User;

public class UserControllerUpdateInfoRequest
{
    [MaxLength(MaxLength.Login)]
    public required string Login { get; set; }
    public DateOnly? Birthday { get; set; }
}
