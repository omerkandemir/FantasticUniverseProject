namespace NLayer.Core.Dto.Abstracts;

public interface ISuccessListResponse<T> : ISuccessResponse, IGetAllResponse<T> where T : IGetResponse
{
}
