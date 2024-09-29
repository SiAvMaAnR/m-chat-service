using System.Text.Json;
using Chat.Application.Common;
using Chat.Application.Services.AuthService.Models;
using Chat.Application.Services.Common;
using Chat.Domain.Common;
using Chat.Domain.Entities.Accounts;
using Chat.Domain.Entities.RefreshTokens;
using Chat.Domain.Entities.Users;
using Chat.Domain.Exceptions;
using Chat.Domain.Services;
using Chat.Domain.Shared.Models;
using Chat.Infrastructure.Services.NotificationsService;
using Chat.Infrastructure.Services.NotificationsService.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;

namespace Chat.Application.Services.AuthService;

public class AuthService : BaseService, IAuthService
{
    private readonly IDataProtectionProvider _protection;
    private readonly AuthBS _authBS;
    private readonly AccountBS _accountBS;
    private readonly INotificationsIS _notificationsIS;

    public AuthService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IAppSettings appSettings,
        IDataProtectionProvider protection,
        AuthBS authBS,
        AccountBS accountBS,
        INotificationsIS notificationsIS
    )
        : base(unitOfWork, context, appSettings)
    {
        _protection = protection;
        _authBS = authBS;
        _accountBS = accountBS;
        _notificationsIS = notificationsIS;
    }

    public async Task<AuthServiceLoginResponse> LoginAsync(AuthServiceLoginRequest request)
    {
        Account account =
            await _accountBS.GetAccountByEmailAsync(request.Email)
            ?? throw new InvalidCredentialsException("Invalid email or password");

        bool isVerify = AuthBS.VerifyPasswordHash(
            request.Password,
            new Password() { Hash = account.PasswordHash, Salt = account.PasswordSalt }
        );

        if (!isVerify)
            throw new InvalidCredentialsException("Wrong password");

        if (account is User { IsBanned: true })
            throw new OperationNotAllowedException("Account was banned");

        string refreshToken = AuthOptions.CreateRefreshToken();
        string accessToken = AuthOptions.CreateAccessToken(
            AuthBS.GetClaims(account),
            _authBS.GetTokenParams()
        );

        RefreshToken newRefreshToken = await _authBS.AddRefreshTokenAsync(account, refreshToken);

        return new AuthServiceLoginResponse()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            RefreshTokenExp = newRefreshToken.ExpiryTime
        };
    }

    public async Task<AuthServiceRefreshTokenResponse> RefreshTokenAsync(
        AuthServiceRefreshTokenRequest request
    )
    {
        RefreshToken refreshToken =
            await _authBS.GetRefreshTokenAsync(request.RefreshToken)
            ?? throw new InvalidCredentialsException("Invalid refresh token");

        if (refreshToken.ExpiryTime < DateTime.Now)
            throw new OperationNotAllowedException("Expired refresh token");

        Account account =
            await _accountBS.GetAccountByIdAsync(refreshToken.AccountId)
            ?? throw new InvalidCredentialsException("Invalid refresh token");

        if (account is User { IsBanned: true })
            throw new OperationNotAllowedException("Account was banned");

        string accessToken = AuthOptions.CreateAccessToken(
            AuthBS.GetClaims(account),
            _authBS.GetTokenParams()
        );

        return new AuthServiceRefreshTokenResponse() { AccessToken = accessToken };
    }

    public async Task<AuthServiceResetTokenResponse> ResetTokenAsync(
        AuthServiceResetTokenRequest request
    )
    {
        Account account =
            await _accountBS.GetAccountByEmailAsync(request.Email)
            ?? throw new NotExistsException("Account not exists");

        string baseUrl = _appSettings.Client.BaseUrl;

        string path = _appSettings.RoutePath.ResetToken;

        string secretKey = _appSettings.Common.SecretKey;

        IDataProtector protector = _protection.CreateProtector(secretKey);

        string resetTokenJson = JsonSerializer.Serialize(
            new ResetToken()
            {
                Id = account.Id,
                Email = request.Email,
                ExpirationDate = DateTime.Now.AddHours(1),
            }
        );

        string resetToken = protector.Protect(resetTokenJson);

        string resetPasswordLink = $"{baseUrl}/{path}?token={resetToken}";

        await _notificationsIS.SendEmail(
            new NotificationsIServiceSendEmailRequest()
            {
                Template = EmailTemplate.ResetPassword,
                Recipient = account.Email,
                Data = new { recipientName = account.Login, resetPasswordLink }
            }
        );

        return new AuthServiceResetTokenResponse() { IsSuccess = true };
    }

    public async Task<AuthServiceResetPasswordResponse> ResetPasswordAsync(
        AuthServiceResetPasswordRequest request
    )
    {
        string secretKey = _appSettings.Common.SecretKey;

        IDataProtector protector = _protection.CreateProtector(secretKey);

        string resetTokenJson = protector.Unprotect(request.ResetToken);

        ResetToken resetToken =
            JsonSerializer.Deserialize<ResetToken>(resetTokenJson)
            ?? throw new IncorrectDataException("Incorrect reset token");

        if (resetToken.ExpirationDate < DateTime.Now)
            throw new OperationNotAllowedException("Reset token has expired");

        Account account =
            await _accountBS.GetAccountByIdAsync(resetToken.Id, true)
            ?? throw new NotExistsException("Account not exists");

        await _authBS.UpdatePasswordAsync(account, request.Password);

        return new AuthServiceResetPasswordResponse() { IsSuccess = true };
    }

    public async Task<AuthServiceRevokeTokenResponse> RevokeTokenAsync(
        AuthServiceRevokeTokenRequest request
    )
    {
        RefreshToken refreshToken =
            await _authBS.GetRefreshTokenAsync(request.RefreshToken)
            ?? throw new InvalidCredentialsException("Invalid refresh token");

        await _authBS.DeleteRefreshTokenAsync(refreshToken);

        return new AuthServiceRevokeTokenResponse() { IsSuccess = true };
    }
}
