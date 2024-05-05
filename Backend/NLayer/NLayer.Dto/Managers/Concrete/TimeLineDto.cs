using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.TimeLine;
using NLayer.Mapper.Responses.TimeLine;

namespace NLayer.Dto.Managers.Concrete;

public class TimeLineDto : ITimeLineDto
{
    private readonly ITimeLineService _timeLineService;
    private readonly IMapper _mapper;
    public TimeLineDto(ITimeLineService timeLineService, IMapper mapper)
    {
        _timeLineService = timeLineService;
        _mapper = mapper;
    }
    public ICreatedResponse Add(CreateTimeLineRequest request)
    {
        var value = _mapper.Map<TimeLine>(request);
        _timeLineService.Add(value);
        var response = _mapper.Map<CreatedTimeLineResponse>(value);
        return response;
    }
    public IUpdatedResponse Update(UpdateTimeLineRequest request)
    {
        var value = _mapper.Map<TimeLine>(request);
        _timeLineService.Update(value);
        var response = _mapper.Map<UpdatedTimeLineResponse>(value);
        return response;
    }
    public IDeletedResponse Delete(DeleteTimeLineRequest request)
    {
        var value = _mapper.Map<TimeLine>(request);
        _timeLineService.Delete(value);
        var response = _mapper.Map<DeletedTimeLineResponse>(value);
        return response;
    }

    public IGetResponse Get(object id)
    {
        var value = _timeLineService.Get(id);
        var response = _mapper.Map<GetAllTimeLineResponse>(value.Data);
        return response;
    }

    public List<GetAllTimeLineResponse> GetAll()
    {
        var value = _timeLineService.GetAll();
        var response = _mapper.Map<List<GetAllTimeLineResponse>>(value.Data);
        return response;
    }
}
