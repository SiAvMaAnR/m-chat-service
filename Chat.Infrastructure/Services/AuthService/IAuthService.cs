using Chat.Infrastructure.Services.AuthService.Models;

namespace Chat.Infrastructure.Services.AuthService;

public interface IAuthIS
{
    Task<AuthIServiceLoginResponse?> LoginAsync(AuthIServiceLoginRequest request);
}
