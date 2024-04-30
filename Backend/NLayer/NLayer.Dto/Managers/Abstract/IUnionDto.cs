using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Requests.Union;
using NLayer.Dto.Responses.Union;

namespace NLayer.Dto.Managers.Abstract;

public interface IUnionDto : IEntityRepositoryDto<
    CreateUnionRequest,
    UpdateUnionRequest,
    DeleteUnionRequest,
    GetAllUnionResponse>
{
}
