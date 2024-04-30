using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Requests.Galaxy;
using NLayer.Dto.Responses.Galaxy;

namespace NLayer.Dto.Managers.Abstract;

public interface IGalaxyDto : IEntityRepositoryDto<
        CreateGalaxyRequest,
        UpdateGalaxyRequest,
        DeleteGalaxyRequest,
        GetAllGalaxyResponse>
{
}
