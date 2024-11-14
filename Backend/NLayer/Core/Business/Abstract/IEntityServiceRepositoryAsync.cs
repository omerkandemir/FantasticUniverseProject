using NLayer.Core.Entities.Abstract;
using NLayer.Core.Utilities.ReturnTypes;

namespace NLayer.Core.Business.Abstract;

public interface IEntityServiceRepositoryAsync<T>
    where T : class, IEntity, new()
{
    Task<IReturnType> AddAsync(T entity);
    Task<IReturnType> UpdateAsync(T entity);
    Task<IReturnType> DeleteAsync(T entity);
    Task<IDataReturnType<List<T>>> GetAllAsync();
    Task<IDataReturnType<T>> GetAsync(object id);
}
