using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Requests.Planet;
using NLayer.Dto.Responses.Planet;

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
