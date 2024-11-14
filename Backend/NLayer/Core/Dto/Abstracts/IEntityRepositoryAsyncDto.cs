namespace NLayer.Core.Dto.Abstracts;

public interface IEntityRepositoryAsyncDto<TAddRequest, TUpdateRequest, TDeleteRequest, TResponse>
    where TAddRequest : class, ICreateRequest, new()
    where TUpdateRequest : class, IUpdateRequest, new()
    where TDeleteRequest : class, IDeleteRequest, new()
    where TResponse : class, IGetResponse, new()
{
    Task<IResponse> AddAsync(TAddRequest request);
    Task<IResponse> UpdateAsync(TUpdateRequest request);
    Task<IResponse> DeleteAsync(TDeleteRequest request);
    Task<List<TResponse>> GetAllAsync();
    Task<IGetResponse> GetAsync(object id);
}
