using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace NLayer.Core.CrossCuttingConcern.Logging.Loggers;

public class DatabaseLogger : ILoggerService
{
    private ILogger _logger;
    public DatabaseLogger()
    {
        var columnOptions = new ColumnOptions(); // Varsayılan kolon seçenekleri
        columnOptions.Store.Remove(StandardColumn.Properties); // Gereksiz kolonların kaldırılması

        var sinkOptions = new MSSqlServerSinkOptions
        {
            TableName = "Logs",
            AutoCreateSqlTable = true
        };

        _logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .WriteTo.Async(a=>a.MSSqlServer(
                   connectionString: @"Data Source=(localdb)\Omer; Initial Catalog=FantasticUniverseProjectDb;",
                   sinkOptions: sinkOptions,
                   columnOptions: columnOptions)) 
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
