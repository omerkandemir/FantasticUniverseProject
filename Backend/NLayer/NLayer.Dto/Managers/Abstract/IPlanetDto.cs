using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Planet;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Planet;

namespace NLayer.Dto.Managers.Abstract;

public interface IPlanetDto : IEntityRepositoryAsyncDto<
    IGetPlanetResponse,
    CreatePlanetRequest,
    UpdatePlanetRequest,
    DeletePlanetRequest,
    GetPlanetResponse,
    GetAllPlanetResponse>
{
}
