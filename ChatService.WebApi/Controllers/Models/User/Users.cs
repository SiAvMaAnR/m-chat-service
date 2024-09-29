using ChatService.Domain.Shared.Models;

namespace ChatService.WebApi.Controllers.Models.Admin;

public class UserControllerUsersRequest
{
    public Pagination? Pagination { get; set; }
    public bool IsLoadImage { get; set; }
}
