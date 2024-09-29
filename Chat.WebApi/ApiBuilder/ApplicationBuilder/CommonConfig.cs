using Chat.Domain.Shared.Constants.Common;
using Chat.WebApi.Middlewares;

namespace Chat.WebApi.ApiBuilder.ApplicationBuilder;

public static partial class ApplicationBuilderExtension
{
    public static void CommonConfiguration(this WebApplication webApplication)
    {
        webApplication.UseMiddleware<TimingMiddleware>();
        webApplication.UseHttpsRedirection();
        webApplication.UseRouting();
        webApplication.UseCors(CorsPolicyName.Default);
        webApplication.UseAuthentication();
        webApplication.UseAuthorization();
        webApplication.MapControllers();
    }
}
