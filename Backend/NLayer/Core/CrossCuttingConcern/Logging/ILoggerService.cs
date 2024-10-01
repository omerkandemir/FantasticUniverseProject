namespace NLayer.Core.CrossCuttingConcern.Logging;

public interface ILoggerService
{
    void LogInformation(string message, object logDetails);
    void LogError(string message, object logDetails);
}
