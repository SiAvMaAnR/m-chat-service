using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ChatService.WebApi.ApiBuilder.ServiceManager;

public static class SwaggerExtension
{
    public static SwaggerGenOptions Config(this SwaggerGenOptions options)
    {
        options.SwaggerDoc("v1", new OpenApiInfo() { Version = "v1", Title = "Chat service API" });

        options.AddSecurityDefinition(
            "oauth2",
            new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            }
        );
        options.OperationFilter<SecurityRequirementsOperationFilter>();
        return options;
    }
}
