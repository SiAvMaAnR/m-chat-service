using Chat.Domain.Shared.Models;
using Chat.Infrastructure.Services.AIService;
using Chat.Infrastructure.Services.AIService.Models;
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
    public async Task<IActionResult> TestRabbitMQ(IAIIS aiIService)
    {
        AIIServiceCreateMessageResponse? result = await aiIService.CreateMessageAsync(
            new AIIServiceCreateMessageRequest()
            {
                ProfileId = 61,
                Messages = [new AIMessage() { Content = "Кто такой кутахпас?", Role = "user" }]
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
