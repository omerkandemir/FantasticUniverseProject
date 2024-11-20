using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Star;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Star;

namespace NLayer.Dto.Managers.Abstract;

public interface IStarDto : IEntityRepositoryAsyncDto<
        IGetStarResponse,
        CreateStarRequest,
        UpdateStarRequest,
        DeleteStarRequest,
        GetStarResponse,
        GetAllStarResponse>
{
}
