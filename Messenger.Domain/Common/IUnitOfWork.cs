﻿namespace MessengerX.Domain.Common;

public partial interface IUnitOfWork : IDisposable
{
    void SaveChanges();
    Task SaveChangesAsync();
}
