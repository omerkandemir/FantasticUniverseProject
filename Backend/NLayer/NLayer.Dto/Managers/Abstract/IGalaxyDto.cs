using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Galaxy;
using NLayer.Mapper.Responses.Galaxy;

namespace NLayer.Dto.Managers.Abstract;

public interface IGalaxyDto : IEntityRepositoryDto<
        CreateGalaxyRequest,
        UpdateGalaxyRequest,
        DeleteGalaxyRequest,
        GetAllGalaxyResponse>
{
}
