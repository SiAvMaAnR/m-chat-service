using Messenger.Domain.Shared.Settings;
using Messenger.Infrastructure.AppSettings;
using Messenger.Notifications.Email;
using Messenger.Notifications.Email.Models;

namespace Messenger.WebApi.ApiBuilder.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddNotificationDependencies(
        this IServiceCollection serviceCollection,
        IConfiguration configuration
    )
    {
        SmtpSettings smtpSettings = AppSettings.GetSection<SmtpSettings>(configuration);

        serviceCollection.AddSingleton<IEmailClient>(
            new EmailClient(
                new SmtpConfig()
                {
                    Email = smtpSettings.Email,
                    Password = smtpSettings.Password,
                    Host = smtpSettings.Host,
                    Port = smtpSettings.Port
                }
            )
        );

        return serviceCollection;
    }
}
