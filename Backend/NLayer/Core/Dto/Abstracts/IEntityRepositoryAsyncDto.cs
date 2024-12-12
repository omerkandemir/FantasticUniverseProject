namespace NLayer.Core.Dto.Abstracts;

public interface IEntityRepositoryAsyncDto<TResponse, TAddRequest, TUpdateRequest, TDeleteRequest, TGetResponse, TGetAllResponse>
    where TResponse :  IGetResponse
    where TAddRequest : class, ICreateRequest, new()
    where TUpdateRequest : class, IUpdateRequest, new()
    where TDeleteRequest : class, IDeleteRequest, new()
    where TGetResponse : class, IGetResponse, new()
    where TGetAllResponse : class, IGetAllResponse<TResponse>, new()
{
    Task<IResponse> AddAsync(TAddRequest request);
    Task<IResponse> UpdateAsync(TUpdateRequest request);
    Task<IResponse> DeleteAsync(TDeleteRequest request);
    Task<TResponse> GetAsync(object id);
    Task<IGetAllResponse<TResponse>> GetAllAsync();
}
