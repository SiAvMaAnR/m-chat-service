using ChatService.Domain.Shared.Models;

namespace ChatService.Application.Services.UserService.Models;

public class UserServiceUsersRequest
{
    public Pagination? Pagination { get; set; }
    public bool IsLoadImage { get; set; }
}
