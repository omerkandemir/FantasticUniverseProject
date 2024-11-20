using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Entities.Abstract;

namespace NLayer.Core.Dto.ReturnTypes;

public class SuccessResponse<T> : ISuccessResponse<T> where T : class, IEntity, new()
{
    public T Entity { get; set; }
    public object Data { get; }
    public string Message { get; }
    public bool Success => true;
    public SuccessResponse(T entity, object data, string message = "İşlem başarılı.")
    {
        Entity = entity;
        Data = data;
        Message = message;
    }
}
public class SuccessResponse : ISuccessResponse
{
    public object Data { get; }
    public bool Success => true;
    public string Message { get; }
    public SuccessResponse(object data, string message = "İşlem başarılı.")
    {
        Data = data;
        Message = message;
    }
}
