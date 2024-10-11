namespace Chat.Infrastructure.Services.AuthService.Models;

public class AuthIServiceLoginRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
