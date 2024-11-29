using Castle.DynamicProxy;
using NLayer.Core.CrossCuttingConcern.Caching;
using NLayer.Core.Utilities.Interceptors;
using NLayer.Core.Utilities.IOC;
using System.Reflection;

namespace NLayer.Core.Aspect.Autofac.Caching;

public class CacheRemoveAspect : MethodInterception
{
    private readonly string _pattern;
    private readonly ICacheManager _cacheManager;
    public CacheRemoveAspect(string pattern)
    {
        _pattern = pattern;
        _cacheManager = AutofacServiceTool.Resolve<ICacheManager>();
    }
    protected override void OnSuccess(IInvocation invocation)
    {
        if (IsAsyncMethod(invocation.Method))
        {
            RemoveCacheAsync().ConfigureAwait(false);
        }
        else
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }


    private bool IsAsyncMethod(MethodInfo methodInfo)
    {
        return (methodInfo.ReturnType == typeof(Task) ||
                (methodInfo.ReturnType.IsGenericType && methodInfo.ReturnType.GetGenericTypeDefinition() == typeof(Task<>)));
    }

    private async Task RemoveCacheAsync()
    {
        await _cacheManager.RemoveByPatternAsync(_pattern);
    }
}
