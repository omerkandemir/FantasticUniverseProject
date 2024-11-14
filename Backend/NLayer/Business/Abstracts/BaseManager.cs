using NLayer.Core.Aspect.Autofac.Caching;
using NLayer.Core.DataAccess.Abstracts;
using NLayer.Core.Entities.Abstract;
using NLayer.Core.Utilities.Infos;
using NLayer.Core.Utilities.ReturnTypes;

namespace NLayer.Business.Abstracts;

public abstract class BaseManager<T, Tdal> 
    where T : class, IEntity, new()
    where Tdal : IEntityRepository<T>  
{
    protected readonly Tdal _tdal;
    protected BaseManager(Tdal tdal)
    {
        _tdal = tdal;
    }
    [CacheRemoveAspect("GetAll")]
    public virtual IReturnType Add(T value)
    {
        try
        {
            _tdal.Add(value);
            return new ReturnType(GetDatasInfo.Added, CrudOperation.Add);
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.AddedFailed, CrudOperation.Add, ex);
        }
    }

    [CacheRemoveAspect("GetAll")]
    public virtual IReturnType Update(T value)
    {
        try
        {
            _tdal.Update(value);
            return new ReturnType(GetDatasInfo.Updated, CrudOperation.Update);
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update, ex);
        }
    }
    [CacheRemoveAspect("GetAll")]
    public virtual IReturnType Delete(T value)
    {
        try
        {
            _tdal.Delete(value);
            return new ReturnType(GetDatasInfo.Deleted, CrudOperation.Delete);
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.DeletedFailed, CrudOperation.Delete, ex);
        }
    }

    [CacheAspect(duration: 60)] 
    public virtual IDataReturnType<T> Get(object id)
    {
        try
        {
            return new DataReturnType<T>(_tdal.Get(x => x.Id == id), GetDatasInfo.SuccessGetData, CrudOperation.Get);
        }
        catch (Exception ex)
        {
            return new DataReturnType<T>(GetDatasInfo.FailedGetData, CrudOperation.Get, ex);
        }
    }

    [CacheAspect(duration: 60)] 
    public virtual IDataReturnType<List<T>> GetAll()
    {
        try
        {
            return new DataReturnType<List<T>>(_tdal.GetAll().ToList(), GetDatasInfo.SuccessListData, CrudOperation.List);
        }
        catch (Exception ex)
        {
            return new DataReturnType<List<T>>(GetDatasInfo.FailedListData, CrudOperation.List, ex);
        }
    }
}


