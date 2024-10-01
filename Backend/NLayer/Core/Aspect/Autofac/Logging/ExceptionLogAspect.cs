using Castle.DynamicProxy;
using NLayer.Core.CrossCuttingConcern.Logging;
using NLayer.Core.CrossCuttingConcern.Logging.LogDetails;
using NLayer.Core.CrossCuttingConcern.Logging.SeriLog;
using NLayer.Core.Utilities.Interceptors;
using NLayer.Core.Utilities.UserOperations;

namespace NLayer.Core.Aspect.Autofac.Logging;

public class ExceptionLogAspect : MethodInterception
{
    private readonly ILoggerService _loggerService;
    public ExceptionLogAspect(Type loggerServiceType = null)
    {
        _loggerService = LogManager.CreateLogger(loggerServiceType);
    }
    public ExceptionLogAspect(ILoggerService loggerService)
    {
        _loggerService = loggerService;
    }

    protected override void OnException(IInvocation invocation, Exception e)
    {
        var logDetail = GetLogDetail(invocation);
        if (logDetail != null)
        {
            logDetail.ExceptionMessage = e.Message;
            _loggerService.LogError("An exception occurred", logDetail);
        }
    }

    private LogDetailWithException GetLogDetail(IInvocation invocation)
    {
        var logParameters = invocation.Arguments.Select((arg, index) => new LogParameter
        {
            Name = invocation.GetConcreteMethod().GetParameters()[index].Name,
            Value = arg,
            Type = arg?.GetType().Name
        }).ToList();

        return new LogDetailWithException
        {
            MethodName = invocation.Method.Name,
            LogParameters = logParameters,
            SessionId = AccessUser.GetSessionId(),
            UserId = AccessUser.GetUserId(),
            IpAddress = AccessUser.GetIpAddress(),
            CorrelationId = AccessUser.GetCorrelationId(),
            BrowserInfo = AccessUser.GetBrowserInfo()
        };
    }
}
