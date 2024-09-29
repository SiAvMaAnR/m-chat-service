using ChatService.WebApi.ApiBuilder.ApplicationBuilder;
using ChatService.WebApi.ApiBuilder.LoggingBuilder;
using ChatService.WebApi.ApiBuilder.ServiceManager;
using ChatService.WebApi.Common;

AppEnvironment.LoadEnvironments();

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

ConfigurationManager config = builder.Configuration;

builder.Services.AddConfigurationDependencies(config);
builder.Services.AddCommonDependencies(config);
builder.Services.AddTransientDependencies();
builder.Services.AddScopedDependencies();
builder.Services.AddSingletonDependencies(config);

builder.Logging.AddCommonConfiguration(config);

WebApplication application = builder.Build();

application.AddEnvironmentConfiguration();
application.CommonConfiguration();
application.HubsConfiguration();
application.SeedsConfiguration();

application.Run();
