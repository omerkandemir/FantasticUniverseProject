using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Planet;
using NLayer.Mapper.Responses.Planet;

namespace NLayer.Dto.Managers.Abstract
{
    public interface IPlanetDto : IEntityRepositoryDto<
        CreatePlanetRequest,
        UpdatePlanetRequest,
        DeletePlanetRequest,
        GetAllPlanetResponse>
    {
    }
}
