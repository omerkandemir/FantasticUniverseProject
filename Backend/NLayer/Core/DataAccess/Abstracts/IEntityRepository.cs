using Microsoft.EntityFrameworkCore.Query;
using NLayer.Core.Entities.Abstract;
using System.Linq.Expressions;

namespace NLayer.Core.DataAccess.Abstracts;

public interface IEntityRepository<T> where T : class, IEntity, new()
{
    List<T> GetAll(Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null); 
    T Get(Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    Task<T> GetAsync(Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
}
