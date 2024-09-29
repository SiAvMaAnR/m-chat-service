using ChatService.Domain.Common;
using ChatService.Domain.Entities.Admins;

namespace ChatService.Domain.Services;

public class AdminBS : DomainService
{
    public AdminBS(IAppSettings appSettings, IUnitOfWork unitOfWork)
        : base(appSettings, unitOfWork) { }

    public async Task<Admin?> GetAdminByIdAsync(int id)
    {
        return await _unitOfWork.Admin.GetAsync(new AdminByIdSpec(id));
    }
}
