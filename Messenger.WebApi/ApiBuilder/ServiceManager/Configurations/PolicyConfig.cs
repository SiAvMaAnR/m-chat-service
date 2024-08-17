﻿using Messenger.Domain.Shared.Constants.Common;
using Messenger.Domain.Shared.Settings;
using Messenger.Infrastructure.AppSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Messenger.WebApi.ApiBuilder.ServiceManager;

public static class PolicyConfigExtension
{
    private static readonly string[] s_allowOrigins = ["http://localhost:3000"];

    public static void PolicyConfig(this AuthorizationOptions authorizationOptions)
    {
        authorizationOptions.AddPolicy(AuthPolicy.OnlyUser, policy => policy.RequireRole("User"));
        authorizationOptions.AddPolicy(AuthPolicy.OnlyAdmin, policy => policy.RequireRole("Admin"));
        authorizationOptions.AddPolicy(
            AuthPolicy.FullAccess,
            policy => policy.RequireAssertion(context => true)
        );
    }

    public static void CorsConfig(this CorsOptions corsOptions, IConfiguration configuration)
    {
        ClientSettings clientSettings = AppSettings.GetSection<ClientSettings>(configuration);

        string[] origins = s_allowOrigins.Concat([clientSettings.BaseUrl]).ToArray();

        corsOptions.AddPolicy(
            CorsPolicyName.Default,
            policy =>
                policy.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
        );
    }
}