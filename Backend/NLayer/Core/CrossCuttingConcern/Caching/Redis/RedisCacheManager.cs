using StackExchange.Redis;

namespace NLayer.Core.CrossCuttingConcern.Caching.Redis;

public class RedisCacheManager : ICacheManager
{
    private readonly IDatabase _redisDb;
    public RedisCacheManager(IConnectionMultiplexer connectionMultiplexer)
    {
        // Dışarıdan gelen connectionMultiplexer ile Redis veritabanı elde ediliyor
        _redisDb = connectionMultiplexer.GetDatabase();
    }
    public T Get<T>(string key)
    {
        var value = _redisDb.StringGet(key);
        return value.HasValue ? Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value) : default;
    }

    public void Add(string key, object data, int duration)
    {
        var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
        _redisDb.StringSet(key, jsonData, TimeSpan.FromMinutes(duration));
    }

    public bool IsAdd(string key)
    {
        return _redisDb.KeyExists(key);
    }

    public void Remove(string key)
    {
        _redisDb.KeyDelete(key);
    }

    public void RemoveByPattern(string pattern)
    {

        var server = _redisDb.Multiplexer.GetServer(_redisDb.Multiplexer.GetEndPoints().First());

        // 0'dan başlayarak SCAN komutu ile anahtarları tarıyoruz
        var cursor = 0;
        do
        {
            // Her iterasyonda küçük bir parça anahtar taranır
            var keys = server.Keys(cursor, pattern: $"*{pattern}*", pageSize: 1000).ToArray();
            cursor = keys.Length == 0 ? 0 : 1; // Eğer anahtar kalmadıysa döngüyü sonlandırırız

            // Pattern ile eşleşen anahtarları siliyoruz
            foreach (var key in keys)
            {
                Console.WriteLine($"Anahtar siliniyor: {key}");
                _redisDb.KeyDelete(key);
            }

        } while (cursor != 0); // Cursor 0 olduğunda tüm anahtarlar taranmış olur
    }
}