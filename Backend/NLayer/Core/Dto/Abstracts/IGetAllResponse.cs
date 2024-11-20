namespace NLayer.Core.Dto.Abstracts;

public interface IGetAllResponse<TResponse> where TResponse : IGetResponse
{
    ICollection<TResponse>? Responses { get; }
}
