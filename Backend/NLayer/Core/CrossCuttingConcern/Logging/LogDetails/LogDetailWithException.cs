namespace NLayer.Core.CrossCuttingConcern.Logging.LogDetails;

public class LogDetailWithException : LogDetail
{
    public string ExceptionMessage { get; set; } = string.Empty;

}
