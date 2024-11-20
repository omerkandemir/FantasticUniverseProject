using NLayer.Core.Aspect.Autofac.Caching;
using NLayer.Core.DataAccess.Abstracts;
using NLayer.Core.Entities.Abstract;
using NLayer.Core.Utilities.Infos;
using NLayer.Core.Utilities.ReturnTypes;

namespace NLayer.Business.Abstracts;

public abstract class BaseManagerAsync<T, Tdal>
    where T : class, IEntity, new()
    where Tdal : IEntityRepository<T>
{
    protected readonly Tdal _tdal;
    protected BaseManagerAsync(Tdal tdal)
    {
        _tdal = tdal;
    }

    [CacheRemoveAspect("GetAllAsync")]
    public virtual async Task<IReturnType> AddAsync(T value)
    {
        try
        {
            await _tdal.AddAsync(value);
            return new ReturnType(GetDatasInfo.Added, CrudOperation.Add);
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.AddedFailed, CrudOperation.Add, ex);
        }
    }

    [CacheRemoveAspect("GetAllAsync")]
    public virtual async Task<IReturnType> UpdateAsync(T value)
    {
        try
        {
            await _tdal.UpdateAsync(value);
            return new ReturnType(GetDatasInfo.Updated, CrudOperation.Update);
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update, ex);
        }
    }
    [CacheRemoveAspect("GetAllAsync")]
    public virtual async Task<IReturnType> DeleteAsync(T value)
    {
        try
        {
            await _tdal.DeleteAsync(value);
            return new ReturnType(GetDatasInfo.Deleted, CrudOperation.Delete);
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.DeletedFailed, CrudOperation.Delete, ex);
        }
    }

    [CacheAspect(duration: 60)]
    public virtual async Task<IDataReturnType<T>> GetAsync(object id)
    {
        try
        {
            var result = await _tdal.GetAsync(x => x.Id == id);
            return new DataReturnType<T>(result, GetDatasInfo.SuccessGetData, CrudOperation.Get);
        }
        catch (Exception ex)
        {
            return new DataReturnType<T>(GetDatasInfo.FailedGetData, CrudOperation.Get, ex);
        }
    }

    [CacheAspect(duration: 60)]
    public virtual async Task<IDataReturnType<ICollection<T>>> GetAllAsync()
    {
        try
        {
            var result = await _tdal.GetAllAsync();
            return new DataReturnType<ICollection<T>>(result.ToList(), GetDatasInfo.SuccessListData, CrudOperation.List);
        }
        catch (Exception ex)
        {
            return new DataReturnType<ICollection<T>>(GetDatasInfo.FailedListData, CrudOperation.List, ex);
        }
    }
}


