using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Universe;
using NLayer.Dto.Responses.Universe;

namespace NLayer.Business.Abstracts;

public interface IUniverseService : IEntityServiceRepository<
    CreatedUniverseResponse, CreateUniverseRequest,
    UpdatedUniverseResponse, UpdateUniverseRequest,
    DeletedUniverseResponse, DeleteUniverseRequest,
    GetAllUniverseResponse>
{
}
