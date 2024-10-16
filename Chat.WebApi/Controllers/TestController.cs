using Chat.Domain.Shared.Models;
using Chat.Infrastructure.RabbitMQ;
using Chat.Persistence.Redis;
using Microsoft.AspNetCore.Mvc;

namespace Chat.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly IRedisClient _redisClient;

    public TestController(IRedisClient redisClient)
    {
        _redisClient = redisClient;
    }

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

    [HttpPost("redis")]
    public async Task<IActionResult> TestRedisSet([FromBody] string data)
    {
        await _redisClient.SetAsync("cache:test", data, TimeSpan.FromSeconds(5));

        return Ok();
    }

    [HttpGet("redis")]
    public async Task<IActionResult> TestRedisGet()
    {
        string? result = await _redisClient.GetAsync("cache:test");

        return Ok(result);
    }

    [HttpGet("check")]
    public IActionResult Check()
    {
        return Ok("OK");
    }
}
