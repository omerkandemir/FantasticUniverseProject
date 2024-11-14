using Castle.DynamicProxy;
using Newtonsoft.Json;
using NLayer.Core.CrossCuttingConcern.Caching;
using NLayer.Core.Utilities.Extensions;
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

        // Senkron ve asenkron metotları ayırmak için belirteç 
        var isAsync = invocation.Method.ReturnType == typeof(Task) ||
                      (invocation.Method.ReturnType.IsGenericType && invocation.Method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>));
        var asyncSuffix = isAsync ? "_Async" : "_Sync";

        var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))}){asyncSuffix}";

        if (isAsync)
        {
            // Asenkron işlem
            InterceptAsync(invocation, key).Wait();
        }
        else
        {
            // Senkron işlem
            InterceptSync(invocation, key);
        }
    }

    private void InterceptSync(IInvocation invocation, string key)
    {
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

    private async Task InterceptAsync(IInvocation invocation, string key)
    {
        if (await _cacheManager.IsAddAsync(key))
        {
            var returnType = invocation.Method.ReturnType.GenericTypeArguments.FirstOrDefault();

            // Cache'deki veri
            var cacheValue = await _cacheManager.GetAsync<object>(key);

            if (cacheValue != null)
            {
                Type targetType = returnType;
                if (returnType != null && returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(IDataReturnType<>))
                {
                    targetType = typeof(DataReturnType<>).MakeGenericType(returnType.GenericTypeArguments);
                }

                // Deserialize işlemi
                var deserializedValue = JsonConvert.DeserializeObject(cacheValue.ToString(), targetType);

                if (deserializedValue != null)
                {
                    var taskResultMethod = typeof(Task).GetMethod(nameof(Task.FromResult)).MakeGenericMethod(typeof(IDataReturnType<>).MakeGenericType(returnType.GenericTypeArguments));
                    invocation.ReturnValue = taskResultMethod.Invoke(null, new object[] { deserializedValue });
                    return;
                }
            }
        }
        // Eğer önbellekte yoksa, orijinal metodu çağır ve sonucu invocation.ReturnValue olarak ata
        await invocation.ProceedAsync();
        await _cacheManager.AddAsync(key, invocation.ReturnValue, _duration);
    }

}