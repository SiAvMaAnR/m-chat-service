using ChatService.Application.Common;
using ChatService.Persistence.DBContext;
using ChatService.WebApi.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace ChatService.WebApi.ApiBuilder.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddCommonDependencies(
        this IServiceCollection serviceCollection,
        IConfiguration config
    )
    {
        string? connection = AppEnvironment.GetDBConnectionString(config);

        serviceCollection.AddOptions();
        serviceCollection.AddDbContext<EFContext>(options => options.UseSqlServer(connection));
        serviceCollection.AddControllers();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddHttpContextAccessor();
        serviceCollection.AddLogging();
        serviceCollection.AddCors(options => options.CorsConfig(config));
        serviceCollection.AddAuthorization(options => options.PolicyConfig());
        serviceCollection
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.Config(config));
        serviceCollection.AddSwaggerGen(options => options.Config());
        serviceCollection.AddDataProtection().PersistKeysToDbContext<EFContext>();
        serviceCollection.AddSignalR(
            (options) =>
            {
                options.MaximumReceiveMessageSize = 25000000;
            }
        );
        serviceCollection.AddHttpClient();

        return serviceCollection;
    }
}
