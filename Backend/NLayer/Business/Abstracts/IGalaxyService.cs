using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Galaxy;
using NLayer.Dto.Responses.Galaxy;

namespace NLayer.Business.Abstracts;

public interface IGalaxyService : IEntityServiceRepository<
    CreatedGalaxyResponse, CreateGalaxyRequest,
    UpdatedGalaxyResponse, UpdateGalaxyRequest,
    DeletedGalaxyResponse, DeleteGalaxyRequest,
    GetAllGalaxyResponse>
{
}
