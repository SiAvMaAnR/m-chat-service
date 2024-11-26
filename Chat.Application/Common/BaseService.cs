using Chat.Application.Common;
using Chat.Domain.Common;
using Chat.Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Chat.Application.Services.Common;

public interface IBaseService { }

public abstract class BaseService(
    IUnitOfWork unitOfWork,
    IHttpContextAccessor context,
    IAppSettings appSettings
) : IBaseService
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IAppSettings _appSettings = appSettings;
    protected readonly UserIdentity _userIdentity = new(context.HttpContext?.User);
    protected int AccountId =>
        _userIdentity.Id ?? throw new OperationNotAllowedException("Failed to get account id");

    protected string Role =>
        _userIdentity.Role ?? throw new OperationNotAllowedException("Failed to get account role");
}
