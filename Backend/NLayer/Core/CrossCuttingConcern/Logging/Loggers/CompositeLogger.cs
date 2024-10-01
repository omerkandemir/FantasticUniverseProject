namespace NLayer.Core.CrossCuttingConcern.Logging.Loggers;

public class CompositeLogger : ILoggerService
{
    private readonly List<ILoggerService> _loggers;
    public CompositeLogger(params ILoggerService[] loggers)
    {
        _loggers = loggers.ToList();
    }

    public void LogInformation(string message, object logDetails)
    {
        foreach (var logger in _loggers)
        {
            logger.LogInformation(message, logDetails);
        }
    }

    public void LogError(string message, object logDetails)
    {
        foreach (var logger in _loggers)
        {
            logger.LogError(message, logDetails);
        }
    }
}
