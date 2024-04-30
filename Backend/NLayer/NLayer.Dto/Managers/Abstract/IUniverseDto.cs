using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Requests.Universe;
using NLayer.Dto.Responses.Universe;

namespace NLayer.Dto.Managers.Abstract;

public interface IUniverseDto : IEntityRepositoryDto<
    CreateUniverseRequest,
    UpdateUniverseRequest,
    DeleteUniverseRequest,
    GetAllUniverseResponse>
{
}
