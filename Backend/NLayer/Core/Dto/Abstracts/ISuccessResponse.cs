using NLayer.Core.Entities.Abstract;

namespace NLayer.Core.Dto.Abstracts;

// Başarı yanıtları için genel arayüz
public interface ISuccessResponse : IResponse
{
    object Data { get; }
}
// Başarı yanıtları için tür özelleştirilmiş arayüz
public interface ISuccessResponse<T> : ISuccessResponse where T : class, IEntity, new()
{
    public T Entity { get; set; }
}
