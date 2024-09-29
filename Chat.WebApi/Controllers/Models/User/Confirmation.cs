using System.ComponentModel.DataAnnotations;
using Chat.Domain.Shared.Constants.Validation;

namespace Chat.WebApi.Controllers.Models.User;

public class UserControllerConfirmationRequest
{
    [MaxLength(MaxLength.Confirmation)]
    public required string Confirmation { get; set; }
}
