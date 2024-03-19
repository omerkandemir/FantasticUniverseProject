using NLayer.Core.Entities.Abstract;
using NLayer.Core.Utilities.ReturnTypes;

namespace NLayer.Core.Business.Abstract;

public interface IEntityServiceRepository<T>
    where T : class, IEntity, new()
{
    IReturnType Add(T entity);
    IReturnType Update(T entity);
    IReturnType Delete(T entity);
    IDataReturnType<List<T>> GetAll();
    IDataReturnType<T> Get(object id);
}
