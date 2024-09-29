using ChatService.Domain.Shared.Constants.Common;
using ChatService.WebApi.Middlewares;

namespace ChatService.WebApi.ApiBuilder.ApplicationBuilder;

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
