﻿using Chat.Application.Services.AccountService.Adapters;
using Chat.Application.Services.AccountService.Models;
using Chat.Application.Services.Common;
using Chat.Domain.Common;
using Chat.Domain.Entities.Accounts;
using Chat.Domain.Entities.Users;
using Chat.Domain.Exceptions;
using Chat.Domain.Services;
using Chat.Persistence.Extensions;
using Microsoft.AspNetCore.Http;

namespace Chat.Application.Services.AccountService;

public class AccountService : BaseService, IAccountService
{
    private readonly AccountBS _accountBS;

    public AccountService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IAppSettings appSettings,
        AccountBS accountBS
    )
        : base(unitOfWork, context, appSettings)
    {
        _accountBS = accountBS;
    }

    public async Task<AccountServiceUploadImageResponse> UploadImageAsync(
        AccountServiceUploadImageRequest request
    )
    {
        Account account =
            await _unitOfWork.Account.GetAsync(new AccountByIdSpec(UserId, true))
            ?? throw new NotExistsException("Account not found");

        string imagePath = _appSettings.FilePath.Image;

        using (var stream = new MemoryStream())
        {
            request.File.CopyTo(stream);

            string? imageBase64 = await FileManager.WriteToFileAsync(
                stream.ToArray(),
                imagePath,
                account.Email
            );

            await _accountBS.UpdateImageAsync(account, imageBase64);
        }

        return new AccountServiceUploadImageResponse() { IsSuccess = true };
    }

    public async Task<AccountServiceImageResponse> GetImageAsync()
    {
        Account account =
            await _accountBS.GetAccountByIdAsync(UserId)
            ?? throw new NotExistsException("Account not found");

        byte[]? image = await FileManager.ReadToBytesAsync(account.Image);

        return new AccountServiceImageResponse() { Image = image };
    }

    public async Task<AccountServiceUpdateStatusResponse> UpdateStatusAsync(
        AccountServiceUpdateStatusRequest request
    )
    {
        Account account =
            await _accountBS.GetAccountByIdAsync(UserId)
            ?? throw new NotExistsException("Account not found");

        await _accountBS.UpdateActivityStatusAsync(account, request.ActivityStatus);

        return new AccountServiceUpdateStatusResponse() { IsSuccess = true };
    }

    public async Task<AccountServiceAccountsResponse> AccountsAsync(
        AccountServiceAccountsRequest request
    )
    {
        IEnumerable<Account> accounts = await _accountBS.GetAccountsAsync(
            UserId,
            request.SearchField
        );

        PaginatorResponse<Account> paginatedData = accounts.Pagination(request.Pagination);

        var adaptedAccounts = paginatedData
            .Collection
            .Select(account => new AccountServiceAccountAdapter(account))
            .ToList();

        if (request.IsLoadImage)
            await Task.WhenAll(adaptedAccounts.Select(account => account.LoadImageAsync()));

        return new AccountServiceAccountsResponse()
        {
            Meta = paginatedData.Meta,
            Accounts = adaptedAccounts
        };
    }

    public async Task<AccountServiceProfileResponse> GetProfileAsync()
    {
        Account user =
            await _accountBS.GetAccountByIdAsync(UserId)
            ?? throw new NotExistsException("User not found");

        return new AccountServiceProfileResponse()
        {
            Login = user.Login,
            Email = user.Email,
            Role = user.Role,
            Birthday = (user as User)?.Birthday
        };
    }

    public async Task<AccountServiceAccountImageResponse> GetAccountImageAsync(
        AccountServiceAccountImageRequest request
    )
    {
        return await Task.FromResult(new AccountServiceAccountImageResponse() { });
    }
}
