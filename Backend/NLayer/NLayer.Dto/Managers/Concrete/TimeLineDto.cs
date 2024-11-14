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
    public async Task<IResponse> AddAsync(CreateTimeLineRequest request)
    {
        TimeLine timeLine = _mapper.Map<TimeLine>(request);
        var result = await _timeLineService.AddAsync(timeLine);
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
    public async Task<IResponse> UpdateAsync(UpdateTimeLineRequest request)
    {
        TimeLine timeLine = _mapper.Map<TimeLine>(request);
        var result = await _timeLineService.UpdateAsync(timeLine);
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
    public async Task<IResponse> DeleteAsync(DeleteTimeLineRequest request)
    {
        TimeLine timeLine = _mapper.Map<TimeLine>(request);
        var result = await _timeLineService.DeleteAsync(timeLine);
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

    public async Task<IGetResponse> GetAsync(object id)
    {
        var value = await _timeLineService.GetAsync(id);
        var response = _mapper.Map<GetAllTimeLineResponse>(value.Data);
        return response;
    }

    public async Task<List<GetAllTimeLineResponse>> GetAllAsync()
    {
        var value = await _timeLineService.GetAllAsync();
        var response = _mapper.Map<List<GetAllTimeLineResponse>>(value.Data);
        return response;
    }
}
