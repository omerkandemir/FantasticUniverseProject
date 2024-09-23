using Castle.DynamicProxy;
using NLayer.Core.CrossCuttingConcern.Caching;
using NLayer.Core.Utilities.Interceptors;
using NLayer.Core.Utilities.IOC;
using NLayer.Core.Utilities.ReturnTypes;

namespace NLayer.Core.Aspect.Autofac.Caching;

public class CacheAspect : MethodInterception
{
    private readonly int _duration;
    private readonly ICacheManager _cacheManager;

    public CacheAspect(int duration = 60)
    {
        _duration = duration;
        _cacheManager = AutofacServiceTool.Resolve<ICacheManager>();
    }

    public override void Intercept(IInvocation invocation)
    {
        var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
        var arguments = invocation.Arguments.ToList();
        var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";

        if (_cacheManager.IsAdd(key))
        {
            // Metodun geri dönüş tipi
            var returnType = invocation.Method.ReturnType;

            // Cache'deki veri
            var cacheValue = _cacheManager.Get<object>(key);

            Type targetType = returnType;

            if (cacheValue != null)
            {
                // Eğer generic IDataReturnType<> ise, somut DataReturnType<> yapısına çevir
                if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(IDataReturnType<>))
                {
                    targetType = typeof(DataReturnType<>).MakeGenericType(returnType.GenericTypeArguments);
                }
                // Deserialize işlemi
                invocation.ReturnValue = Newtonsoft.Json.JsonConvert.DeserializeObject(cacheValue.ToString(), targetType);
                return;
            }
        }
        // Cache'de yoksa metod normal çalışır ve sonuç cache'e eklenir
        invocation.Proceed();
        _cacheManager.Add(key, invocation.ReturnValue, _duration);
    }
}