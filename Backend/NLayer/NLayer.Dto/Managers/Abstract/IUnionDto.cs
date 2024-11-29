using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Union;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Union;

namespace NLayer.Dto.Managers.Abstract;

public interface IUnionDto : IEntityRepositoryAsyncDto<
    IGetUnionResponse,
    CreateUnionRequest,
    UpdateUnionRequest,
    DeleteUnionRequest,
    GetUnionResponse,
    GetAllUnionResponse>
{
}
