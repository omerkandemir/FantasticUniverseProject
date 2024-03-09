using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Dto.Requests.TimeLine;
using NLayer.Dto.Responses.TimeLine;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class TimeLineManager : ITimeLineService
{
    private readonly ITimeLineDal _timeLineDal;
    public TimeLineManager(ITimeLineDal timeLineDal)
    {
            _timeLineDal = timeLineDal;
    }
    public CreatedTimeLineResponse Add(CreateTimeLineRequest createRequest)
    {
        TimeLine timeLine = new();
        timeLine.UniverseId = createRequest.UniverseId;
        timeLine.StartingAdventureId = createRequest.StartingAdventureId;

        _timeLineDal.Add(timeLine);

        CreatedTimeLineResponse createdTimeLineResponse = new CreatedTimeLineResponse();
        createdTimeLineResponse.Id = timeLine.Id;
        createdTimeLineResponse.UniverseId = timeLine.UniverseId;
        createdTimeLineResponse.StartingAdventureId = timeLine.StartingAdventureId;
        createdTimeLineResponse.CreatedDate = timeLine.CreatedDate;

        return createdTimeLineResponse;
    }

    public DeletedTimeLineResponse Delete(DeleteTimeLineRequest deleteRequest)
    {
        TimeLine timeLine = new() { Id = deleteRequest.Id };
        _timeLineDal.Delete(timeLine);
        DeletedTimeLineResponse deletedTimeLineResponse = new DeletedTimeLineResponse();
        deletedTimeLineResponse.Id = timeLine.Id;
        return deletedTimeLineResponse;
    }

    public GetAllTimeLineResponse Get(int id)
    {
        GetAllTimeLineResponse getAllTimeLineResponse = new GetAllTimeLineResponse();
        TimeLine timeLine = _timeLineDal.Get(x => x.Id == id);
        getAllTimeLineResponse.Id = timeLine.Id;
        getAllTimeLineResponse.UniverseId = timeLine.UniverseId;
        getAllTimeLineResponse.StartingAdventureId = timeLine.StartingAdventureId;
        getAllTimeLineResponse.CreatedDate = timeLine.CreatedDate;
        return getAllTimeLineResponse;
    }

    public List<GetAllTimeLineResponse> GetAll()
    {
        List<TimeLine> timeLines = _timeLineDal.GetAll();

        List<GetAllTimeLineResponse> getAllTimeLineResponses = new List<GetAllTimeLineResponse>();

        foreach (var timeLine in timeLines)
        {
            GetAllTimeLineResponse getAllTimeLineResponse = new GetAllTimeLineResponse();
            getAllTimeLineResponse.Id = timeLine.Id;
            getAllTimeLineResponse.UniverseId = timeLine.UniverseId;
            getAllTimeLineResponse.StartingAdventureId = timeLine.StartingAdventureId;
            getAllTimeLineResponse.CreatedDate = timeLine.CreatedDate;

            getAllTimeLineResponses.Add(getAllTimeLineResponse);
        }
        return getAllTimeLineResponses;
    }

    public UpdatedTimeLineResponse Update(UpdateTimeLineRequest updateRequest)
    {
        TimeLine timeLine = new();
        timeLine.Id = updateRequest.Id;
        timeLine.UniverseId = updateRequest.UniverseId;
        timeLine.StartingAdventureId = updateRequest.StartingAdventureId;

        _timeLineDal.Update(timeLine);

        UpdatedTimeLineResponse updatedTimeLineResponse = new UpdatedTimeLineResponse();
        updatedTimeLineResponse.Id = timeLine.Id;
        updatedTimeLineResponse.UniverseId = timeLine.UniverseId;
        updatedTimeLineResponse.StartingAdventureId = timeLine.StartingAdventureId;
        updatedTimeLineResponse.UpdatedDate = timeLine.UpdatedDate;
        return updatedTimeLineResponse;
    }
}
