using NLayer.Core.CrossCuttingConcern.Logging.Loggers;

namespace NLayer.Core.CrossCuttingConcern.Logging.SeriLog;

public static class LogManager
{
    public static ILoggerService CreateLogger(Type loggerServiceType)
    {
        return loggerServiceType switch
        {
            null => new CompositeLogger(new FileLogger(), new DatabaseLogger(), new RedisLogger(), new ElasticSearchLogger()),  // Dosyaya, Veritabanına, Redise ve ElasticSearch e Loglama
            Type type when type == typeof(FileLogger) => new FileLogger(),         // Sadece dosyaya logla
            Type type when type == typeof(DatabaseLogger) => new DatabaseLogger(), // Sadece veritabanına logla
            Type type when type == typeof(RedisLogger) => new RedisLogger(),       // Sadece Redis'e logla
            Type type when type == typeof(ElasticSearchLogger) => new ElasticSearchLogger(), // ElasticSearch'e logla
            _ => throw new ArgumentException("Invalid logger type")                // Geçersiz logger tipi
        };
    }
}
