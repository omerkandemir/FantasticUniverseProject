using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Entities.Abstract;

namespace NLayer.Core.Business.Abstract;

public interface IEntityServiceRepository<T>
    where T : class, IEntity, new()
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    List<T> GetAll();
    T Get(int id);
}
