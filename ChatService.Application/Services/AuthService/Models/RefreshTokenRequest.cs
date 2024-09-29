namespace ChatService.Application.Services.AuthService.Models;

public class AuthServiceRefreshTokenRequest
{
    public required string RefreshToken { get; set; }
}
