using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Entities.Abstract;

namespace NLayer.Core.Dto.ReturnTypes;

public class SuccessListResponse<T> : ISuccessListResponse<T> where T : IGetResponse
{
    public bool Success => true;
    public ICollection<T>? Responses { get; }
    public object Data { get; }
    public string Message { get; }


    public SuccessListResponse(ICollection<T>? responses, object data, string message = "Liste başarıyla döndürüldü.")
    {
        Responses = responses;
        Data = data;
        Message = message;
    }
}
