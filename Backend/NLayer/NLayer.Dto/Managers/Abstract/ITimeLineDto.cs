using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Requests.TimeLine;
using NLayer.Dto.Responses.TimeLine;

namespace NLayer.Dto.Managers.Abstract;

public interface ITimeLineDto : IEntityRepositoryDto<
        CreateTimeLineRequest,
        UpdateTimeLineRequest,
        DeleteTimeLineRequest,
        GetAllTimeLineResponse>
{
}
