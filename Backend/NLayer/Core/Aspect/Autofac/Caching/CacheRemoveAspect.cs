using Castle.DynamicProxy;
using NLayer.Core.CrossCuttingConcern.Caching;
using NLayer.Core.Utilities.Interceptors;
using NLayer.Core.Utilities.IOC;

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
        _cacheManager.RemoveByPattern(_pattern);
    }
}
