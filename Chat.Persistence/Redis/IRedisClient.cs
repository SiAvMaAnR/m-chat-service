namespace Chat.Persistence.Redis;

public interface IRedisClient
{
    Task SetAsync(string key, string value, TimeSpan? expiry = null);
    Task<string?> GetAsync(string key);
    Task DeleteKeyAsync(string key);
    Task SetKeyExpiryAsync(string key, TimeSpan expiry);
    Task<TimeSpan?> GetKeyTTLAsync(string key);
}
