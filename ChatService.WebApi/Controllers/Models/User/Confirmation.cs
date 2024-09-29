using System.ComponentModel.DataAnnotations;
using ChatService.Domain.Shared.Constants.Validation;

namespace ChatService.WebApi.Controllers.Models.User;

public class UserControllerConfirmationRequest
{
    [MaxLength(MaxLength.Confirmation)]
    public required string Confirmation { get; set; }
}
