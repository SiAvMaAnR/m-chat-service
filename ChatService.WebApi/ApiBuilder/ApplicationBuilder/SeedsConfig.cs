using ChatService.Persistence.DBContext;
using ChatService.Persistence.Seeds;

namespace ChatService.WebApi.ApiBuilder.ApplicationBuilder;

public static partial class ApplicationBuilderExtension
{
    public static void SeedsConfiguration(this WebApplication webApplication)
    {
        using IServiceScope scope = webApplication.Services.CreateScope();

        EFContext dbContext = scope.ServiceProvider.GetRequiredService<EFContext>();
        ILogger<EFContext> logger = scope.ServiceProvider.GetRequiredService<ILogger<EFContext>>();

        SeedsInitiator.Apply(dbContext, logger);
    }
}
