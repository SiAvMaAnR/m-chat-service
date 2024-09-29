using Chat.Domain.Common;

namespace Chat.Domain.Services;

public abstract class DomainService(IAppSettings appSettings, IUnitOfWork unitOfWork) : IDomainService
{
    protected readonly IAppSettings _appSettings = appSettings;
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
}
