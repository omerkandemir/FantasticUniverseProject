using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.Galaxy;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GalaxiesController : ControllerBase
{
    private readonly IGalaxyDto _galaxyDto;
    public GalaxiesController(IGalaxyDto galaxyDto)
    {
        _galaxyDto = galaxyDto;
    }
    [HttpPost("Ekle")]
    public async Task<IActionResult> Add([FromBody] CreateGalaxyRequest createRequest)
    {
        var response = await _galaxyDto.AddAsync(createRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPut("Güncelle")]
    public async Task<IActionResult> Update([FromBody] UpdateGalaxyRequest updateRequest)
    {
        var response = await _galaxyDto.UpdateAsync(updateRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpDelete("Sil{id}")]
    public async Task<IActionResult> Delete(DeleteGalaxyRequest deleteRequest)
    {
        var response = await _galaxyDto.DeleteAsync(deleteRequest);
        if (response.Success)
        return Ok(response);
        return BadRequest(response);
    }

    [HttpGet("Listele")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _galaxyDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _galaxyDto.GetAsync(id);
        return Ok(response);
    }
}
