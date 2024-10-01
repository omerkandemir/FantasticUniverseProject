using Moq;
using NLayer.Core.CrossCuttingConcern.Logging;
using NLayer.Core.CrossCuttingConcern.Logging.Loggers;
using NLayer.Core.CrossCuttingConcern.Logging.SeriLog;

namespace FantasticUniverse.Tests;

public class LogManagerTests
{
    [Fact]
    public void CreateLogger_ShouldReturn_FileLogger_WhenTypeIsFileLogger()
    {
        // Hazırlama
        var loggerServiceType = typeof(FileLogger);

        // Eylem
        var logger = LogManager.CreateLogger(loggerServiceType);

        // Doğrulama
        Assert.IsType<FileLogger>(logger);
    }

    [Fact]
    public void CreateLogger_ShouldReturn_DatabaseLogger_WhenTypeIsDatabaseLogger()
    {
        // Hazırlama
        var loggerServiceType = typeof(DatabaseLogger);

        // Eylem
        var logger = LogManager.CreateLogger(loggerServiceType);

        // Doğrulama
        Assert.IsType<DatabaseLogger>(logger);
    }

    [Fact]
    public void CreateLogger_ShouldReturn_CompositeLogger_WhenTypeIsNull()
    {
        // Eylem
        var logger = LogManager.CreateLogger(null);

        // Doğrulama
        Assert.IsType<CompositeLogger>(logger);
    }

    [Fact]
    public void LogInformation_ShouldCallAllLoggers()
    {
        // Hazırlama
        var mockFileLogger = new Mock<ILoggerService>();
        var mockDbLogger = new Mock<ILoggerService>();
        var compositeLogger = new CompositeLogger(mockFileLogger.Object, mockDbLogger.Object);

        var message = "Test message";
        var logDetails = new object();

        // Eylem
        compositeLogger.LogInformation(message, logDetails);

        // Doğrulama
        mockFileLogger.Verify(l => l.LogInformation(message, logDetails), Times.Once);
        mockDbLogger.Verify(l => l.LogInformation(message, logDetails), Times.Once);
    }

    [Fact]
    public void LogError_ShouldCallAllLoggers()
    {
        // Hazırlama
        var mockFileLogger = new Mock<ILoggerService>();
        var mockDbLogger = new Mock<ILoggerService>();
        var compositeLogger = new CompositeLogger(mockFileLogger.Object, mockDbLogger.Object);

        var message = "Error message";
        var logDetails = new object();

        // Eylem
        compositeLogger.LogError(message, logDetails);

        // Doğrulama
        mockFileLogger.Verify(l => l.LogError(message, logDetails), Times.Once);
        mockDbLogger.Verify(l => l.LogError(message, logDetails), Times.Once);
    }
}
