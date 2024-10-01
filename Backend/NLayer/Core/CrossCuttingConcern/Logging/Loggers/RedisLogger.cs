using Newtonsoft.Json;
using Serilog;
using StackExchange.Redis;

namespace NLayer.Core.CrossCuttingConcern.Logging.Loggers;

public class RedisLogger : ILoggerService
{
    private readonly ILogger _logger;
    private readonly IDatabase _db;
    private readonly string _listKey = "logstash";  // Redis'te kullanılacak key
    public RedisLogger()
    {
       var redis = ConnectionMultiplexer.Connect("localhost:6379");
        _db = redis.GetDatabase();

        _logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .CreateLogger();
    }
    public async void LogInformation(string message, object logDetails)
    {
        var logMessage = $"{message}: {JsonConvert.SerializeObject(logDetails)}";
        _logger.Information("{Message} {@LogDetails}", message, logDetails);
       await WriteToRedisAsync(logMessage);
    }
    public async void LogError(string message, object logDetails)
    {
        var logMessage = $"ERROR: {message}: {JsonConvert.SerializeObject(logDetails)}";
        _logger.Error("{Message} {@LogDetails}", message, logDetails);
        await WriteToRedisAsync(logMessage);
    }
    private async Task WriteToRedisAsync(string logMessage)
    {
        await _db.ListRightPushAsync(_listKey, logMessage);
    }
}