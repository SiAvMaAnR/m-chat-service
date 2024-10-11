using Chat.Infrastructure.Services.AuthService.Models;

namespace Chat.Infrastructure.Services.NotificationsService;

public interface IAuthIS
{
    Task<AuthIServiceLoginResponse?> LoginAsync(AuthIServiceLoginRequest request);
}
