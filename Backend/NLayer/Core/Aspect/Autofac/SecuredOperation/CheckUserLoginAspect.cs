using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using NLayer.Core.Utilities.Interceptors;
using NLayer.Core.Utilities.Messages;

namespace NLayer.Core.Aspect.Autofac.SecuredOperation;

public class CheckUserLoginAspect : MethodInterception
{
    protected override void OnBefore(IInvocation invocation)
    {
        var httpContextAccessor = GetHttpContextAccessor(invocation);
        var httpContext = httpContextAccessor?.HttpContext;
        if (httpContext == null || !httpContext.User.Identity.IsAuthenticated)
        {
            throw new UnauthorizedAccessException(AspectMessages.AuthorizationDenied);
        }
    }

    private IHttpContextAccessor GetHttpContextAccessor(IInvocation invocation)
    {
        var httpContextAccessor = (IHttpContextAccessor)invocation.Arguments.FirstOrDefault(x => x is IHttpContextAccessor);
        if (httpContextAccessor == null)
        {
            throw new InvalidOperationException("IHttpContextAccessor could not be resolved.");
        }
        return httpContextAccessor;
    }
}
