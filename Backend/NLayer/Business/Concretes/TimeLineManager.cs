using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.TimeLine;
using NLayer.Dto.Responses.TimeLine;

namespace NLayer.Business.Concretes;

public class TimeLineManager : ITimeLineService
{
    public CreatedTimeLineResponse Add(CreateTimeLineRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public DeletedTimeLineResponse Delete(DeleteTimeLineRequest deleteRequest)
    {
        throw new NotImplementedException();
    }

    public GetAllTimeLineResponse Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<GetAllTimeLineResponse> GetAll()
    {
        throw new NotImplementedException();
    }

    public UpdatedTimeLineResponse Update(UpdateTimeLineRequest updateRequest)
    {
        throw new NotImplementedException();
    }
}
