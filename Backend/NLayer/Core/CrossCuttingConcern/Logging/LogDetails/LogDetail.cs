namespace NLayer.Core.CrossCuttingConcern.Logging.LogDetails;

public class LogDetail
{
    public string MethodName { get; set; }
    public List<LogParameter> LogParameters { get; set; } = new List<LogParameter>();
    public string SessionId { get; set; }
    public int UserId { get; set; }
    public string IpAddress { get; set; }
    public string CorrelationId { get; set; }
    public string BrowserInfo { get; set; }

}
