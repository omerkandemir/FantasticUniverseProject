using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.TimeLine;
using NLayer.Dto.Responses.TimeLine;
using NLayer.Entities.Concretes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeLinesController : ControllerBase
{
    private readonly ITimeLineService _timeLineService;
    private readonly IMapper _mapper;
    public TimeLinesController(ITimeLineService timeLineService, IMapper mapper)
    {
        _timeLineService = timeLineService;
        _mapper = mapper;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateTimeLineRequest createRequest)
    {
        var value = _mapper.Map<TimeLine>(createRequest);
        _timeLineService.Add(value);
        var response = _mapper.Map<CreatedTimeLineResponse>(value);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateTimeLineRequest updateRequest)
    {
        var value = _mapper.Map<TimeLine>(updateRequest);
        _timeLineService.Update(value);
        var response = _mapper.Map<UpdatedTimeLineResponse>(value);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteTimeLineRequest deleteRequest)
    {
        var value = _mapper.Map<TimeLine>(deleteRequest);
        _timeLineService.Delete(value);
        var response = _mapper.Map<DeletedTimeLineResponse>(value);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var value = _timeLineService.GetAll();
        var response = _mapper.Map<List<GetAllTimeLineResponse>>(value.Data);
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var value = _timeLineService.Get(Id);
        var response = _mapper.Map<GetAllTimeLineResponse>(value.Data);
        return Ok(response);
    }
}
