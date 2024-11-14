using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Star;
using NLayer.Mapper.Responses.Star;

namespace NLayer.Dto.Managers.Abstract;

public interface IStarDto : IEntityRepositoryAsyncDto<
        CreateStarRequest,
        UpdateStarRequest,
        DeleteStarRequest,
        GetAllStarResponse>
{
}
