using Chat.Application.Services.AccountService;
using Chat.Application.Services.ChannelService;
using Chat.Application.Services.ChatService;
using Chat.Application.Services.UserService;
using Chat.Domain.Common;
using Chat.Domain.Services;
using Chat.Infrastructure.Services.AIService;
using Chat.Infrastructure.Services.AuthService;
using Chat.Infrastructure.Services.NotificationsService;
using Chat.Persistence.Redis;
using Chat.Persistence.UnitOfWork;

namespace Chat.WebApi.ApiBuilder.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddScopedDependencies(
        this IServiceCollection serviceCollection
    )
    {
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddScoped<IRedisClient, RedisClient>();

        serviceCollection.AddScoped<INotificationsIS, NotificationsIS>();
        serviceCollection.AddScoped<IAuthIS, AuthIS>();
        serviceCollection.AddScoped<IAIIS, AIIS>();

        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IAccountService, AccountService>();
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
