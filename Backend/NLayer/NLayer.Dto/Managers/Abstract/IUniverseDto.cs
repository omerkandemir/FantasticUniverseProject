using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Universe;
using NLayer.Mapper.Responses.Universe;

namespace NLayer.Dto.Managers.Abstract;

public interface IUniverseDto : IEntityRepositoryDto<
    CreateUniverseRequest,
    UpdateUniverseRequest,
    DeleteUniverseRequest,
    GetAllUniverseResponse>
{
}
