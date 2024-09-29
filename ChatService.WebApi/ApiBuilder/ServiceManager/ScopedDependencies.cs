using ChatService.Application.Services.AccountService;
using ChatService.Application.Services.AuthService;
using ChatService.Application.Services.ChannelService;
using ChatService.Application.Services.ChatService;
using ChatService.Application.Services.UserService;
using ChatService.Domain.Common;
using ChatService.Domain.Services;
using ChatService.Infrastructure.RabbitMQ;
using ChatService.Infrastructure.Services.NotificationsService;
using ChatService.Persistence.UnitOfWork;

namespace ChatService.WebApi.ApiBuilder.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddScopedDependencies(
        this IServiceCollection serviceCollection
    )
    {
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddScoped<IRabbitMQProducer, RabbitMQProducer>();
        serviceCollection.AddScoped<IRabbitMQConsumer, RabbitMQConsumer>();

        serviceCollection.AddScoped<INotificationsIS, NotificationsIS>();

        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IAccountService, AccountService>();
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IChannelService, ChannelService>();
        serviceCollection.AddScoped<IChatService, ChatService>();

        serviceCollection.AddScoped<UserBS>();
        serviceCollection.AddScoped<AccountBS>();
        serviceCollection.AddScoped<AuthBS>();
        serviceCollection.AddScoped<AdminBS>();
        serviceCollection.AddScoped<ChannelBS>();
        serviceCollection.AddScoped<ChatBS>();
        serviceCollection.AddScoped<AttachmentBS>();

        return serviceCollection;
    }
}
