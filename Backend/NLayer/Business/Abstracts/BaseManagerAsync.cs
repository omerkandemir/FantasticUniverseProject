using NLayer.Core.Aspect.Autofac.Caching;
using NLayer.Core.DataAccess.Abstracts;
using NLayer.Core.Entities.Abstract;
using NLayer.Core.Utilities.Infos;
using NLayer.Core.Utilities.ReturnTypes;

namespace NLayer.Business.Abstracts;

public abstract class BaseManagerAsync<T, Tdal,TId>
    where T : class, IEntity<TId>, new()
    where Tdal : IEntityRepository<T>
{
    protected readonly Tdal _tdal;
    protected BaseManagerAsync(Tdal tdal)
    {
        _tdal = tdal;
    }

    /// <summary>
    /// Güvenli bir şekilde bir CRUD işlemi gerçekleştirir.
    /// </summary>
    /// <param name="action">Gerçekleştirilecek işlem (asenkron bir işlem)</param>
    /// <param name="operation">CRUD işlemi türü</param>
    /// <returns>Başarı ya da hata durumu döner</returns>
    protected async Task<IReturnType> ExecuteSafely(Func<Task> action, CrudOperation operation)
    {
        try
        {
            await action();
            return new ReturnType(GetDatasInfo.SuccessfulOperation(operation), operation);
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.FailedOperation(operation), operation, ex);
        }
    }

    /// <summary>
    /// Veri döndüren işlemleri güvenli bir şekilde gerçekleştirir.
    /// </summary>
    /// <typeparam name="TResult">Dönen verinin türü</typeparam>
    /// <param name="query">Gerçekleştirilecek sorgu (asenkron bir işlem)</param>
    /// <param name="operation">CRUD işlemi türü (örneğin, Listeleme, Getirme)</param>
    /// <returns>İşlemin sonucunu ve başarı durumu hakkında bilgi dönen bir IDataReturnType nesnesi</returns>
    protected async Task<IDataReturnType<TResult>> ExecuteQuerySafelyWithResult<TResult>(Func<Task<TResult>> query, CrudOperation operation)
    {
        try
        {
            var result = await query();
            return new DataReturnType<TResult>(result, GetDatasInfo.SuccessfulOperation(operation), operation);
        }
        catch (Exception ex)
        {
            return new DataReturnType<TResult>(GetDatasInfo.FailedOperation(operation), operation, ex);
        }
    }


    [CacheRemoveAspect("GetAllAsync")]
    public virtual Task<IReturnType> AddAsync(T value) => ExecuteSafely(() => _tdal.AddAsync(value), CrudOperation.Add);


    [CacheRemoveAspect("GetAllAsync")]
    public virtual Task<IReturnType> UpdateAsync(T value) => ExecuteSafely(() => _tdal.UpdateAsync(value), CrudOperation.Update);

    [CacheRemoveAspect("GetAllAsync")]
    public virtual Task<IReturnType> DeleteAsync(T value) => ExecuteSafely(() => _tdal.DeleteAsync(value), CrudOperation.Delete);


    [CacheAspect(duration: 60)]
    public virtual async Task<IDataReturnType<T>> GetAsync(TId id) => await ExecuteQuerySafelyWithResult(() => _tdal.GetAsync(x =>x.Id.Equals(id)), CrudOperation.Get);


    [CacheAspect(duration: 60)]
    public virtual async Task<IDataReturnType<ICollection<T>>> GetAllAsync() => await ExecuteQuerySafelyWithResult(() => _tdal.GetAllAsync(), CrudOperation.List);
}


