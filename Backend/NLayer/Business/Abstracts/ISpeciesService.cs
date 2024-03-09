using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Species;
using NLayer.Dto.Responses.Species;

namespace NLayer.Business.Abstracts;

public interface ISpeciesService : IEntityServiceRepository<
    CreatedSpeciesResponse, CreateSpeciesRequest,
    UpdatedSpeciesResponse, UpdateSpeciesRequest,
    DeletedSpeciesResponse, DeleteSpeciesRequest,
    GetAllSpeciesResponse>
{
}
