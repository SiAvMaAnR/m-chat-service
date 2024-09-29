using Microsoft.AspNetCore.Http;

namespace ChatService.Application.Services.AccountService.Models;

public class AccountServiceUploadImageRequest
{
    public required IFormFile File { get; set; }
}
