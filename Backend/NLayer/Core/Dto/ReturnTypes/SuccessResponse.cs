using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Entities.Abstract;

namespace NLayer.Core.Dto.ReturnTypes;

public class SuccessResponse<T> : ISuccessResponse<T> where T : class, IEntity, new()
{
    public T Entity { get; set; }
    public object Data { get; }
    public bool Success => true;


    public SuccessResponse(object data, T entity)
    {
        Data = data;
        Entity = entity;
    }

}
