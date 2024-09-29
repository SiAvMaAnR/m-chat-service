using Chat.Domain.Common;
using Chat.Domain.Entities.Admins;

namespace Chat.Domain.Services;

public class AdminBS : DomainService
{
    public AdminBS(IAppSettings appSettings, IUnitOfWork unitOfWork)
        : base(appSettings, unitOfWork) { }

    public async Task<Admin?> GetAdminByIdAsync(int id)
    {
        return await _unitOfWork.Admin.GetAsync(new AdminByIdSpec(id));
    }
}
