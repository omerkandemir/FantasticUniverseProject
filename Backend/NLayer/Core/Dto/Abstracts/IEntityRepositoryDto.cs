using NLayer.Core.Dto.ReturnTypes;

namespace NLayer.Core.Dto.Abstracts;

public interface IEntityRepositoryDto<TAddRequest, TUpdateRequest, TDeleteRequest, TResponse>
    where TAddRequest : class, ICreateRequest, new()
    where TUpdateRequest : class, IUpdateRequest, new()
    where TDeleteRequest : class, IDeleteRequest, new()
    where TResponse : class, IGetResponse, new()
{
    IErrorResponse Add(TAddRequest request);
    IErrorResponse Update(TUpdateRequest request);
    IErrorResponse Delete(TDeleteRequest request);
    List<TResponse> GetAll();
    IGetResponse Get(object id);
}
