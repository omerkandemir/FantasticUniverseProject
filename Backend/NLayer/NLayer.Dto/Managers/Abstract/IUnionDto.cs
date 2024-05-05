using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Union;
using NLayer.Mapper.Responses.Union;

namespace NLayer.Dto.Managers.Abstract;

public interface IUnionDto : IEntityRepositoryDto<
    CreateUnionRequest,
    UpdateUnionRequest,
    DeleteUnionRequest,
    GetAllUnionResponse>
{
}
