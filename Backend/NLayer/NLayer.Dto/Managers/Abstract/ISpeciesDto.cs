using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Requests.Species;
using NLayer.Dto.Responses.Species;

namespace NLayer.Dto.Managers.Abstract;

public interface ISpeciesDto : IEntityRepositoryDto<
        CreateSpeciesRequest,
        UpdateSpeciesRequest,
        DeleteSpeciesRequest,
        GetAllSpeciesResponse>
{
}
