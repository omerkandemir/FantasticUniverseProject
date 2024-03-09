using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Planet;
using NLayer.Dto.Responses.Planet;

namespace NLayer.Business.Abstracts;

public interface IPlanetService : IEntityServiceRepository<
    CreatedPlanetResponse, CreatePlanetRequest,
    UpdatedPlanetResponse, UpdatePlanetRequest,
    DeletedPlanetResponse, DeletePlanetRequest,
    GetAllPlanetResponse>
{
}
