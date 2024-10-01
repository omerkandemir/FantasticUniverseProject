using Moq;
using Newtonsoft.Json;
using NLayer.Core.CrossCuttingConcern.Logging.Loggers;
using StackExchange.Redis;

namespace FantasticUniverse.Tests;

public class RedisLoggerTests
{
    private readonly Mock<IDatabase> _mockDb;
    private readonly Mock<IConnectionMultiplexer> _mockConnectionMultiplexer;
    private readonly RedisLogger _redisLogger;

    public RedisLoggerTests()
    {
        // Mock IDatabase ve ConnectionMultiplexer
        _mockDb = new Mock<IDatabase>();
        _mockConnectionMultiplexer = new Mock<IConnectionMultiplexer>();

        // ConnectionMultiplexer'in GetDatabase metodunun mock IDatabase'i döndürmesinin sağlanması
        _mockConnectionMultiplexer.Setup(r => r.GetDatabase(It.IsAny<int>(), It.IsAny<object>())).Returns(_mockDb.Object);

        // Gerçek RedisLogger sınıfını mock ConnectionMultiplexer ile test edilmesi
        _redisLogger = new RedisLogger();

        // Reflection ile RedisLogger içindeki ConnectionMultiplexer'i mock ile değiştirilmesi
        var fieldInfo = typeof(RedisLogger).GetField("_db", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        fieldInfo.SetValue(_redisLogger, _mockDb.Object);
    }

    [Fact]
    public async Task LogInformation_ShouldWriteToRedis()
    {
        // Hazırlama
        var message = "Test message";
        var logDetails = new { Id = 1, Name = "Test" };
        var expectedLogMessage = $"{message}: {JsonConvert.SerializeObject(logDetails)}";

        // Eylem
        _redisLogger.LogInformation(message, logDetails);

        // Doğrulama
        _mockDb.Verify(db => db.ListRightPushAsync("logstash", expectedLogMessage, It.IsAny<When>(), It.IsAny<CommandFlags>()), Times.Once);
    }

    [Fact]
    public async Task LogError_ShouldWriteToRedis()
    {
        // Hazırlama
        var message = "Error message";
        var logDetails = new { Error = "TestError" };
        var expectedLogMessage = $"ERROR: {message}: {JsonConvert.SerializeObject(logDetails)}";

        // Eylem
        _redisLogger.LogError(message, logDetails);

        // Doğrulama
        _mockDb.Verify(db => db.ListRightPushAsync("logstash", expectedLogMessage, It.IsAny<When>(), It.IsAny<CommandFlags>()), Times.Once);
    }
}
