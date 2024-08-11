using NLayer.Core.Entities.Abstract;

namespace NLayer.Core.Dto.Abstracts;

public interface ISuccessResponse<T> : IResponse where T : class, IEntity, new()
{
    public T Entity { get; set; }
    public object Data { get; }
}
