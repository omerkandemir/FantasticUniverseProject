using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
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
    public IResponse Add(CreateTimeLineRequest request)
    {
        TimeLine timeLine = _mapper.Map<TimeLine>(request);
        var result = _timeLineService.Add(timeLine);
        var response = _mapper.Map<CreatedTimeLineResponse>(timeLine);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<TimeLine>(response, timeLine);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Update(UpdateTimeLineRequest request)
    {
        TimeLine timeLine = _mapper.Map<TimeLine>(request);
        var result = _timeLineService.Update(timeLine);
        var response = _mapper.Map<UpdatedTimeLineResponse>(timeLine);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<TimeLine>(response, timeLine);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Delete(DeleteTimeLineRequest request)
    {
        TimeLine timeLine = _mapper.Map<TimeLine>(request);
        var result = _timeLineService.Delete(timeLine);
        var response = _mapper.Map<DeletedTimeLineResponse>(timeLine);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<TimeLine>(response, timeLine);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
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
