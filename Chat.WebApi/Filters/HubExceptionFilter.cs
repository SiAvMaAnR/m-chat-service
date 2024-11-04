using Microsoft.AspNetCore.SignalR;

namespace Chat.WebApi.Filters;

public class HubExceptionFilter : IHubFilter
{
    private readonly ILogger<HubExceptionFilter> _logger;

    public HubExceptionFilter(ILogger<HubExceptionFilter> logger)
    {
        _logger = logger;
    }

    public async ValueTask<object?> InvokeMethodAsync(
        HubInvocationContext invocationContext,
        Func<HubInvocationContext, ValueTask<object?>> next
    )
    {
        try
        {
            return await next(invocationContext);
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Hub method exception: {Message}",
                exception.Message
            );
            throw new HubException(exception.Message);
        }
    }
}
