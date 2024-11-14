using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Species;
using NLayer.Mapper.Responses.Species;

namespace NLayer.Dto.Managers.Abstract;

public interface ISpeciesDto : IEntityRepositoryAsyncDto<
        CreateSpeciesRequest,
        UpdateSpeciesRequest,
        DeleteSpeciesRequest,
        GetAllSpeciesResponse>
{
}
