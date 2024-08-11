using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Entities.Abstract;

namespace NLayer.Core.Dto.ReturnTypes;

public class SuccessListResponse<T> : ISuccessResponse<T>, IGetResponse where T : class, IEntity, new()
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public object Data { get; }
    public T Entity { get; set; }
    public SuccessListResponse(object data, T entity)
    {
        Data = data;
        Entity = entity;
    }
    public bool Success => true;
}
