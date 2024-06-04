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
    public IErrorResponse Add(CreateTimeLineRequest request)
    {
        var value = _mapper.Map<TimeLine>(request);
        var result = _timeLineService.Add(value);
        var response = _mapper.Map<CreatedTimeLineResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Update(UpdateTimeLineRequest request)
    {
        var value = _mapper.Map<TimeLine>(request);
        var result = _timeLineService.Update(value);
        var response = _mapper.Map<UpdatedTimeLineResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Delete(DeleteTimeLineRequest request)
    {
        var value = _mapper.Map<TimeLine>(request);
        var result = _timeLineService.Delete(value);
        var response = _mapper.Map<DeletedTimeLineResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
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
