using Castle.DynamicProxy;
using NLayer.Core.CrossCuttingConcern.Logging;
using NLayer.Core.CrossCuttingConcern.Logging.LogDetails;
using NLayer.Core.CrossCuttingConcern.Logging.SeriLog;
using NLayer.Core.Utilities.Interceptors;
using NLayer.Core.Utilities.UserOperations;

namespace NLayer.Core.Aspect.Autofac.Logging;

public class LogAspect : MethodInterception
{
    private readonly ILoggerService _loggerService;
    public LogAspect(Type loggerServiceType = null)
    {
        _loggerService = LogManager.CreateLogger(loggerServiceType);
    }
    public LogAspect(ILoggerService loggerService)
    {
        _loggerService = loggerService;
    }
    protected override void OnAfter(IInvocation invocation)
    {
        var logDetail = GetLogDetail(invocation);
        _loggerService.LogInformation("Method execution completed", logDetail);
    }
    protected override void OnException(IInvocation invocation, Exception e)
    {
        var logDetail = GetLogDetail(invocation, true) as LogDetailWithException;
        if (logDetail != null)
        {
            logDetail.ExceptionMessage = e.Message;
            _loggerService.LogError("An exception occurred", logDetail);
        }
    }
    private LogDetail GetLogDetail(IInvocation invocation, bool isException = false)
    {
        var logParameters = invocation.Arguments.Select((arg, index) => new LogParameter
        {
            Name = invocation.GetConcreteMethod().GetParameters()[index].Name,
            Value = arg,
            Type = arg?.GetType().Name
        }).ToList();

        LogDetail logDetail;

        if (isException)
        {
            logDetail = new LogDetailWithException
            {
                ExceptionMessage = string.Empty,
                LogParameters = logParameters 
            };
        }
        else
        {
            logDetail = new LogDetail
            {
                LogParameters = logParameters
            };
        }
        LogInfos(invocation, logDetail);
        return logDetail;
    }
    private void LogInfos(IInvocation invocation, LogDetail logDetail)
    {
        logDetail.MethodName = $"{invocation.TargetType.Name}.{invocation.Method.Name}"; ;
        logDetail.LogParameters = logDetail.LogParameters;
        logDetail.SessionId = AccessUser.GetSessionId();
        logDetail.UserId = AccessUser.GetUserId();
        logDetail.IpAddress = AccessUser.GetIpAddress();
        logDetail.CorrelationId = AccessUser.GetCorrelationId();
        logDetail.BrowserInfo = AccessUser.GetBrowserInfo();
    }
}
