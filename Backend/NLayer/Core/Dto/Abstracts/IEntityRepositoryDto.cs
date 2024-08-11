namespace NLayer.Core.Dto.Abstracts;

public interface IEntityRepositoryDto<TAddRequest, TUpdateRequest, TDeleteRequest, TResponse>
    where TAddRequest : class, ICreateRequest, new()
    where TUpdateRequest : class, IUpdateRequest, new()
    where TDeleteRequest : class, IDeleteRequest, new()
    where TResponse : class, IGetResponse, new()
{
    IResponse Add(TAddRequest request);
    IResponse Update(TUpdateRequest request);
    IResponse Delete(TDeleteRequest request);
    List<TResponse> GetAll();
    IGetResponse Get(object id);
}
