using Chat.Domain.Entities.Admins;
using Chat.Domain.Services;
using Chat.Domain.Shared.Models;
using Chat.Persistence.DBContext;

namespace Chat.Persistence.Seeds.DefaultUsers;

internal static partial class DefaultUsersSeed
{
    public static void CreateAdmins(EFContext eFContext)
    {
        if (!eFContext.Admins.Any())
        {
            var admins = new[]
            {
                new
                {
                    Email = "admin@admin.com",
                    Login = "Admin",
                    Password = "Sosnova61S"
                }
            };

            IEnumerable<Admin> adminList = admins.Select(admin =>
            {
                Password password = AuthBS.CreatePasswordHash(admin.Password);

                return new Admin(admin.Email, admin.Login, password.Hash, password.Salt);
            });

            eFContext.Admins.AddRange(adminList);
            eFContext.SaveChanges();
        }
    }
}
