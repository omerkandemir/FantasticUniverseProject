using Newtonsoft.Json;
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
        return value.HasValue ? JsonConvert.DeserializeObject<T>(value) : default;
    }
    public async Task<T> GetAsync<T>(string key)
    {
        var value = await _redisDb.StringGetAsync(key);
        return value.HasValue ? JsonConvert.DeserializeObject<T>(value) : default;
    }
    public void Add(string key, object data, int duration)
    {
        var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        _redisDb.StringSet(key, jsonData, TimeSpan.FromMinutes(duration));
    }
    public async Task AddAsync(string key, object data, int duration)
    {
        var jsonData = JsonConvert.SerializeObject(data, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        await _redisDb.StringSetAsync(key, jsonData, TimeSpan.FromMinutes(duration));
    }

    public bool IsAdd(string key)
    {
        return _redisDb.KeyExists(key);
    }
    public async Task<bool> IsAddAsync(string key)
    {
        return await _redisDb.KeyExistsAsync(key);
    }
    public void Remove(string key)
    {
        _redisDb.KeyDelete(key);
    }
    public async Task RemoveAsync(string key)
    {
        await _redisDb.KeyDeleteAsync(key);
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
                _redisDb.KeyDelete(key);
            }

        } while (cursor != 0); 
    }
    public async Task RemoveByPatternAsync(string pattern)
    {
        var server = _redisDb.Multiplexer.GetServer(_redisDb.Multiplexer.GetEndPoints().First());
        var tasks = new List<Task>();
        var cursor = 0;
        do
        {
            var keys = server.Keys(cursor, pattern: $"*{pattern}*", pageSize: 1000).ToArray();
            cursor = keys.Length == 0 ? 0 : 1; // Eğer anahtar kalmadıysa döngüyü sonlandır

            foreach (var key in keys)
            {
                tasks.Add(_redisDb.KeyDeleteAsync(key));
            }
        } while (cursor != 0); 

        // Tüm silme işlemlerini aynı anda başlatır ve tamamlanmasını bekler
        await Task.WhenAll(tasks);
    }
}