﻿using MessengerX.Domain.Shared.Settings;

namespace MessengerX.WebApi.ApiConfigurations.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddConfigurationDependencies(
        this IServiceCollection serviceCollection,
        IConfiguration config
    )
    {
        serviceCollection.Configure<CommonSettings>(config.GetSection(CommonSettings.Path));
        serviceCollection.Configure<AuthSettings>(config.GetSection(AuthSettings.Path));
        serviceCollection.Configure<ClientSettings>(config.GetSection(ClientSettings.Path));
        serviceCollection.Configure<RoutePathSettings>(config.GetSection(RoutePathSettings.Path));
        serviceCollection.Configure<FilePathSettings>(config.GetSection(FilePathSettings.Path));
        serviceCollection.Configure<SmtpSettings>(config.GetSection(SmtpSettings.Path));
        serviceCollection.Configure<MesBrokerSettings>(
            config.GetSection(MesBrokerSettings.Path)
        );

        return serviceCollection;
    }
}
