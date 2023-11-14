using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace MessengerX.WebApi.ApiConfigurations.Common;

public static class PolicyConfigExtension
{
    private static readonly string[] AllowOrigins =
    {
        "http://localhost:3000",
        "https://localhost:3000"
    };

    public static void PolicyConfig(this AuthorizationOptions authorizationOptions)
    {
        authorizationOptions.AddPolicy("OnlyUser", policy => policy.RequireRole("User"));
        authorizationOptions.AddPolicy("OnlyAdmin", policy => policy.RequireRole("Admin"));
        authorizationOptions.AddPolicy(
            "AccessToAll",
            policy => policy.RequireRole("User").RequireRole("Admin")
        );
    }

    public static void CorsConfig(this CorsOptions corsOptions)
    {
        corsOptions.AddPolicy(
            "CorsPolicy",
            policy =>
                policy
                    .WithOrigins(AllowOrigins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
        );
    }
}