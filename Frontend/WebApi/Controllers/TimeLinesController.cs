using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.TimeLine;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeLinesController : ControllerBase
{
    private readonly ITimeLineDto _timeLineDto;
    public TimeLinesController(ITimeLineDto timeLineDto)
    {
        _timeLineDto = timeLineDto;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateTimeLineRequest createRequest)
    {
        var response = _timeLineDto.Add(createRequest);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateTimeLineRequest updateRequest)
    {
        var response = _timeLineDto.Update(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteTimeLineRequest deleteRequest)
    {
        var response = _timeLineDto.Delete(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _timeLineDto.GetAll();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _timeLineDto.Get(Id);
        return Ok(response);
    }
}
