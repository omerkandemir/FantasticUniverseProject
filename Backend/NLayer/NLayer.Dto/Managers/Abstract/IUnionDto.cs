using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Union;
using NLayer.Mapper.Responses.Union;

namespace NLayer.Dto.Managers.Abstract;

public interface IUnionDto : IEntityRepositoryAsyncDto<
    CreateUnionRequest,
    UpdateUnionRequest,
    DeleteUnionRequest,
    GetAllUnionResponse>
{
}
