using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Requests.Star;
using NLayer.Dto.Responses.Star;

namespace NLayer.Dto.Managers.Abstract;

public interface IStarDto : IEntityRepositoryDto<
        CreateStarRequest,
        UpdateStarRequest,
        DeleteStarRequest,
        GetAllStarResponse>
{
}
