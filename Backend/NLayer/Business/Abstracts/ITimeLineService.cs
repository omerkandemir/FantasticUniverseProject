using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.TimeLine;
using NLayer.Dto.Responses.TimeLine;

namespace NLayer.Business.Abstracts;

public interface ITimeLineService : IEntityServiceRepository<
    CreatedTimeLineResponse, CreateTimeLineRequest,
    UpdatedTimeLineResponse, UpdateTimeLineRequest,
    DeletedTimeLineResponse, DeleteTimeLineRequest,
    GetAllTimeLineResponse>
{
}
