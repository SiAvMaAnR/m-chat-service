using ChatService.Application.Services.AuthService.Models;
using ChatService.Application.Services.Common;

namespace ChatService.Application.Services.AuthService;

public interface IAuthService : IBaseService
{
    Task<AuthServiceLoginResponse> LoginAsync(AuthServiceLoginRequest request);
    Task<AuthServiceResetTokenResponse> ResetTokenAsync(AuthServiceResetTokenRequest request);
    Task<AuthServiceResetPasswordResponse> ResetPasswordAsync(
        AuthServiceResetPasswordRequest request
    );
    Task<AuthServiceRefreshTokenResponse> RefreshTokenAsync(AuthServiceRefreshTokenRequest request);
    Task<AuthServiceRevokeTokenResponse> RevokeTokenAsync(AuthServiceRevokeTokenRequest request);
}
