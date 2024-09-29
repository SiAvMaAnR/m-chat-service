using Microsoft.AspNetCore.Http;

namespace Chat.Application.Services.AccountService.Models;

public class AccountServiceUploadImageRequest
{
    public required IFormFile File { get; set; }
}
