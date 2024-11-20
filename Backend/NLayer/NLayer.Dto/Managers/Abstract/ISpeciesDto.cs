using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Species;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Species;

namespace NLayer.Dto.Managers.Abstract;

public interface ISpeciesDto : IEntityRepositoryAsyncDto<
        IGetSpeciesResponse,
        CreateSpeciesRequest,
        UpdateSpeciesRequest,
        DeleteSpeciesRequest,
        GetSpeciesResponse,
        GetAllSpeciesResponse>
{
}
