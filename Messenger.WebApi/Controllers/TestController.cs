using Messenger.Domain.Shared.Models;
using Messenger.Infrastructure.RabbitMQ;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet("rabbit-mq")]
    public async Task<IActionResult> TestRabbitMQ(IRabbitMQProducer rabbitMQProducer)
    {
        AIMessage? result = await rabbitMQProducer.Emit<AIMessage>(
            RMQ.Queue.Ai,
            RMQ.AIQueuePattern.CreateMessage,
            new
            {
                message = new { content = "Кто такой цицерон?", role = "user" },
                apiKey = new
                {
                    model = "GigaChat",
                    content = "NzIwYjVhNWQtODFjNC00MzFlLWFhNGEtY2ZkNjMyYWUxZWEwOjBkYTlkOTJmLTQ5ZGItNDNkMS1hOTFjLTFlZmVmMTMxOTE5Ng==",
                },
                temperature = 0.6,
                messages = new List<object>(),
            }
        );

        return Ok(result);
    }

    [HttpGet("check")]
    public IActionResult Check()
    {
        return Ok("OK");
    }
}
