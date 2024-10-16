using StackExchange.Redis;

namespace Chat.Persistence.Redis;

public class RedisClient : IRedisClient
{
    private readonly IConnectionMultiplexer _redis;

    public RedisClient(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }

    public async Task SetAsync(string key, string value, TimeSpan? expiry = null)
    {
        IDatabase db = _redis.GetDatabase();
        await db.StringSetAsync(key, value, expiry);
    }

    public async Task<string?> GetAsync(string key)
    {
        IDatabase db = _redis.GetDatabase();
        return await db.StringGetAsync(key);
    }

    public async Task DeleteKeyAsync(string key)
    {
        IDatabase db = _redis.GetDatabase();
        await db.KeyDeleteAsync(key);
    }

    public async Task SetKeyExpiryAsync(string key, TimeSpan expiry)
    {
        IDatabase db = _redis.GetDatabase();
        await db.KeyExpireAsync(key, expiry);
    }

    public async Task<TimeSpan?> GetKeyTTLAsync(string key)
    {
        IDatabase db = _redis.GetDatabase();
        return await db.KeyTimeToLiveAsync(key);
    }
}
