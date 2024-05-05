using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.TimeLine;
using NLayer.Mapper.Responses.TimeLine;

namespace NLayer.Dto.Managers.Abstract;

public interface ITimeLineDto : IEntityRepositoryDto<
        CreateTimeLineRequest,
        UpdateTimeLineRequest,
        DeleteTimeLineRequest,
        GetAllTimeLineResponse>
{
}
