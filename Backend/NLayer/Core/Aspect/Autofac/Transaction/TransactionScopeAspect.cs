using Castle.DynamicProxy;
using NLayer.Core.Utilities.Interceptors;
using System.Transactions;

namespace NLayer.Core.Aspect.Autofac.Transaction;

[Serializable]
public class TransactionScopeAspect : MethodInterception
{

    public override void Intercept(IInvocation invocation)
    {
        // Asenkron işlem mi değil mi kontrolü
        if (invocation.Method.ReturnType == typeof(Task) ||
            (invocation.Method.ReturnType.IsGenericType && invocation.Method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>)))
        {
            // Asenkron işlemler için
            InterceptAsync(invocation).GetAwaiter().GetResult();
        }
        else
        {
            // Senkron işlemler için 
            InterceptSync(invocation);
        }
    }
    private async Task InterceptAsync(IInvocation invocation)
    {
        using (var transactionScope = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted },
                    TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {
                invocation.Proceed(); 
                var task = (Task)invocation.ReturnValue; 
                await task; 

                transactionScope.Complete();
            }
            catch (Exception e)
            {
                transactionScope.Dispose();
                OnException(invocation, e);
                throw;
            }
        }
    }
    private void InterceptSync(IInvocation invocation)
    {
        using (var transactionScope = new TransactionScope(
                                TransactionScopeOption.Required,
                                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted },
                                TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {
                invocation.Proceed();
                transactionScope.Complete();
            }
            catch (Exception e)
            {
                transactionScope.Dispose();
                OnException(invocation, e);
                throw;
            }
        }
    }
}
