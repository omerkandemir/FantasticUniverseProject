using Castle.DynamicProxy;

namespace NLayer.Core.Utilities.Extensions;

public static class InvocationExtensions
{
    /// <summary>
    /// ProceedAsync` metodu, `invocation` nesnesindeki metodu çağırır ve sonucu asenkron olarak döndürür
    /// </summary>
    /// <param name="invocation"></param>
    /// <returns></returns>
    public static async Task ProceedAsync(this IInvocation invocation)
    {
        // Invocation metodunu çağır ve dönen sonucu `Task` olarak al
        var task = (Task)invocation.Method.Invoke(invocation.InvocationTarget, invocation.Arguments);
        // Task tamamlanana kadar bekle
        await task.ConfigureAwait(false);
        // Eğer metot bir değer döndürüyorsa, bu değeri `ReturnValue` olarak ata
        invocation.ReturnValue = task.GetType().GetProperty("Result")?.GetValue(task);
    }
}
