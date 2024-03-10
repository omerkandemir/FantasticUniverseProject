using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.TimeLine;
using NLayer.Dto.Responses.TimeLine;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeLinesController : ControllerBase
{
    ITimeLineService _timeLineService;
    public TimeLinesController(ITimeLineService timeLineService)
    {
        _timeLineService = timeLineService;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateTimeLineRequest createdRequest)
    {
        CreatedTimeLineResponse createdResponse = _timeLineService.Add(createdRequest);
        return Ok(createdResponse);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateTimeLineRequest updatedRequest)
    {
        UpdatedTimeLineResponse updatedResponse = _timeLineService.Update(updatedRequest);
        return Ok(updatedResponse);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteTimeLineRequest deleteRequest)
    {
        DeletedTimeLineResponse deletedResponse = _timeLineService.Delete(deleteRequest);
        return Ok(deletedResponse);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        return Ok(_timeLineService.GetAll());
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        return Ok(_timeLineService.Get(Id));
    }
}
