using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Galaxy;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Galaxy;

namespace NLayer.Dto.Managers.Abstract;

public interface IGalaxyDto : IEntityRepositoryAsyncDto<
        IGetGalaxyResponse,
        CreateGalaxyRequest,
        UpdateGalaxyRequest,
        DeleteGalaxyRequest,
        GetGalaxyResponse,
        GetAllGalaxyResponse>
{
}
