using Serilog;

namespace NLayer.Core.CrossCuttingConcern.Logging.Loggers;

public class FileLogger : ILoggerService
{
    private ILogger _logger;
    public FileLogger()
    {
        var logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "logs");
        var logPath = Path.Combine(logDirectory, "log-.txt");

        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }

        _logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Async(a=>a.File(new Serilog.Formatting.Json.JsonFormatter(), logPath, rollingInterval: RollingInterval.Day))
            .CreateLogger();
    }
    public void LogInformation(string message, object logDetails)
    {
        _logger.Information("{Message} {@LogDetails}", message, logDetails);
    }
    public void LogError(string message, object logDetails)
    {
        _logger.Error("{Message} {@LogDetails}", message, logDetails);
    }
}
