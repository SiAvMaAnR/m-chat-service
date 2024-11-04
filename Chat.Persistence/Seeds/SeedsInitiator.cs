using Chat.Persistence.DBContext;
using Chat.Persistence.Seeds.DefaultUsers;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace Chat.Persistence.Seeds;

public static class SeedsInitiator
{
    public static void Apply(EFContext eFContext, ILogger<EFContext> logger)
    {
        using IDbContextTransaction transaction = eFContext.Database.BeginTransaction();
        try
        {
            DefaultUsersSeed.CreateAdmins(eFContext);
            DefaultUsersSeed.CreateUsers(eFContext);
            DefaultUsersSeed.CreateAIBots(eFContext);

            transaction.Commit();
            logger.LogInformation("Seeds: Success");
        }
        catch (Exception exception)
        {
            transaction.Rollback();
            logger.LogDebug(exception, "Seeds: Error");
        }
    }
}
