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
        var response = _timeLineDto.AddAsync(createRequest);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateTimeLineRequest updateRequest)
    {
        var response = _timeLineDto.UpdateAsync(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteTimeLineRequest deleteRequest)
    {
        var response = _timeLineDto.DeleteAsync(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _timeLineDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _timeLineDto.GetAsync(Id);
        return Ok(response);
    }
}
