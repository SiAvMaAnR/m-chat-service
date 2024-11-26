namespace Chat.Infrastructure.Services.AuthService.Models;

public class AuthIServiceLoginResponse
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
    public DateTime RefreshTokenExp { get; set; }
}
