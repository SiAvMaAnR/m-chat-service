using ChatService.Domain.Shared.Settings;
using ChatService.Infrastructure.AppSettings;
using NReco.Logging.File;

namespace ChatService.WebApi.ApiBuilder.LoggingBuilder;

public static partial class LoggingBuilderExtension
{
    public static ILoggingBuilder AddCommonConfiguration(
        this ILoggingBuilder loggingBuilder,
        IConfiguration configuration
    )
    {
        FilePathSettings filePathSettings = AppSettings.GetSection<FilePathSettings>(configuration);

        loggingBuilder.ClearProviders();
        loggingBuilder.AddConsole();
        loggingBuilder.AddFile(
            $"{filePathSettings.Logger}/information.log",
            config =>
            {
                config.Append = true;
                config.MinLevel = LogLevel.Information;
            }
        );
        loggingBuilder.AddFile(
            $"{filePathSettings.Logger}/error.log",
            config =>
            {
                config.Append = true;
                config.MinLevel = LogLevel.Error;
            }
        );
        loggingBuilder.AddFile(
            $"{filePathSettings.Logger}/trace.log",
            config =>
            {
                config.Append = true;
                config.MinLevel = LogLevel.Trace;
            }
        );

        return loggingBuilder;
    }
}
