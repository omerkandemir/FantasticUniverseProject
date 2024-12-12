using NLayer.Core.Entities.Abstract;
using NLayer.Core.Utilities.ReturnTypes;

namespace NLayer.Core.Business.Abstract;

public interface IEntityServiceRepositoryAsync<T, TId>
    where T : class, IEntity<TId>, new()
{
    Task<IReturnType> AddAsync(T entity);
    Task<IReturnType> UpdateAsync(T entity);
    Task<IReturnType> DeleteAsync(T entity);
    Task<IDataReturnType<ICollection<T>>> GetAllAsync();
    Task<IDataReturnType<T>> GetAsync(TId id);
}
