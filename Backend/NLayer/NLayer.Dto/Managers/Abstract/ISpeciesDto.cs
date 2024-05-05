using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Species;
using NLayer.Mapper.Responses.Species;

namespace NLayer.Dto.Managers.Abstract;

public interface ISpeciesDto : IEntityRepositoryDto<
        CreateSpeciesRequest,
        UpdateSpeciesRequest,
        DeleteSpeciesRequest,
        GetAllSpeciesResponse>
{
}
