using NLayer.Core.DataAccess.Abstracts;
using NLayer.Core.Entities.Abstract;
using NLayer.Core.Utilities.Infos;
using NLayer.Core.Utilities.ReturnTypes;

namespace NLayer.Business.Abstracts;

public abstract class BaseManager<T, Tdal>
    where T : class, IEntity, new()
    where Tdal : IEntityRepository<T>
{
    private readonly Tdal _tdal;
    protected BaseManager(Tdal tdal)
    {
        _tdal = tdal;
    }
    public virtual IReturnType Add(T Value)
    {
        try
        {
            _tdal.Add(Value);
            return new ReturnType(GetDatasInfo.Added, CrudOperation.Add);
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.AddedFailed, CrudOperation.Add, ex);
        }
    }
    public virtual IReturnType Update(T Value)
    {
        try
        {
            _tdal.Update(Value);
            return new ReturnType(GetDatasInfo.Updated, CrudOperation.Update);
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update, ex);
        }
    }
    public virtual IReturnType Delete(T Value)
    {
        try
        {
            _tdal.Delete(Value);
            return new ReturnType(GetDatasInfo.Deleted, CrudOperation.Delete);
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.DeletedFailed, CrudOperation.Delete, ex);
        }
    }
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
    public virtual IDataReturnType<List<T>> GetAll()
    {
        try
        {
            return new DataReturnType<List<T>>(_tdal.GetAll().ToList(), GetDatasInfo.SuccessListData,CrudOperation.List);
        }
        catch (Exception ex)
        {
            return new DataReturnType<List<T>>(GetDatasInfo.FailedListData, CrudOperation.List, ex);
        }
    }
}


