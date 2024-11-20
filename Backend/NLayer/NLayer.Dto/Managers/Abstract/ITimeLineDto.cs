using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.TimeLine;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.TimeLine;

namespace NLayer.Dto.Managers.Abstract;

public interface ITimeLineDto : IEntityRepositoryAsyncDto<
        IGetTimeLineResponse,
        CreateTimeLineRequest,
        UpdateTimeLineRequest,
        DeleteTimeLineRequest,
        GetTimeLineResponse,
        GetAllTimeLineResponse>
{
}
