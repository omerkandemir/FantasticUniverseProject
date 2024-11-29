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
    public async Task<IActionResult> Add([FromBody] CreateTimeLineRequest createRequest)
    {
        var response = await _timeLineDto.AddAsync(createRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPut("Güncelle")]
    public async Task<IActionResult> Update([FromBody] UpdateTimeLineRequest updateRequest)
    {
        var response = await _timeLineDto.UpdateAsync(updateRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpDelete("Sil{id}")]
    public async Task<IActionResult> Delete(DeleteTimeLineRequest deleteRequest)
    {
        var response = await _timeLineDto.DeleteAsync(deleteRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpGet("Listele")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _timeLineDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _timeLineDto.GetAsync(id);
        return Ok(response);
    }
}
