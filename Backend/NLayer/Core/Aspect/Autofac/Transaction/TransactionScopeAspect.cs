using Castle.DynamicProxy;
using NLayer.Core.Utilities.Interceptors;
using System.Transactions;

namespace NLayer.Core.Aspect.Autofac.Transaction;

[Serializable]
public class TransactionScopeAspect : MethodInterception
{

    public override void Intercept(IInvocation invocation)
    {
        using (var transactionScope = new TransactionScope(TransactionScopeOption.Required,
                        new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted })) //IsolationLevel veritabanı işlemlerinin diğer işlemlerden nasıl izole edileceğini belirler. ReadCommitted, bir işlem sırasında okunan verilerin, başka bir işlem tarafından henüz tamamlanmamış değişikliklerini engeller.
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
