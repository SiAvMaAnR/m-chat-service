using Chat.Domain.Shared.Models;

namespace Chat.WebApi.Controllers.Models.Admin;

public class UserControllerUsersRequest
{
    public Pagination? Pagination { get; set; }
    public bool IsLoadImage { get; set; }
}
