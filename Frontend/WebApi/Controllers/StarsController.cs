using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.Star;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StarsController : ControllerBase
{
    private readonly IStarDto _starDto;
    public StarsController(IStarDto starDto)
    {
        _starDto = starDto;
    }
    [HttpPost("Ekle")]
    public async Task<IActionResult> Add([FromBody] CreateStarRequest createRequest)
    {
        var response = await _starDto.AddAsync(createRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPut("Güncelle")]
    public async Task<IActionResult> Update([FromBody] UpdateStarRequest updateRequest)
    {
        var response = await _starDto.UpdateAsync(updateRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpDelete("Sil{id}")]
    public async Task<IActionResult> Delete(DeleteStarRequest deleteRequest)
    {
        var response = await _starDto.DeleteAsync(deleteRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpGet("Listele")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _starDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _starDto.GetAsync(id);
        return Ok(response);
    }
}
