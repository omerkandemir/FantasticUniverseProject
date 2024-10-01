using Elasticsearch.Net;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace NLayer.Core.CrossCuttingConcern.Logging.Loggers;

public class ElasticSearchLogger : ILoggerService
{
    private readonly ILogger _logger;

    public ElasticSearchLogger()
    {
        _logger = new LoggerConfiguration()
           .WriteTo.Async(a=>a.Elasticsearch(new ElasticsearchSinkOptions(new Uri("https://localhost:9200"))
           {
               AutoRegisterTemplate = true,
               IndexFormat = "logstash-{0:yyyy.MM.dd}",
               ModifyConnectionSettings = x => x.BasicAuthentication("elastic", "password")
                                           .ServerCertificateValidationCallback(CertificateValidations.AllowAll),
           }))
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
