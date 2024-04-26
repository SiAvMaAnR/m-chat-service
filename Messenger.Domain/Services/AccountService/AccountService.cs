﻿using MessengerX.Domain.Common;
using MessengerX.Domain.Entities.Accounts;

namespace MessengerX.Domain.Services;

public class AccountBS : DomainService
{
    public AccountBS(IAppSettings appSettings, IUnitOfWork unitOfWork)
        : base(appSettings, unitOfWork) { }

    public async Task<Account?> GetAccountByIdAsync(int? id)
    {
        return await _unitOfWork.Account.GetAsync(account => account.Id == id);
    }

    public async Task<Account?> GetAccountByEmailAsync(string? email)
    {
        return await _unitOfWork.Account.GetAsync(account => account.Email == email);
    }
}