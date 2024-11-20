using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.Planet;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlanetsController : ControllerBase
{
    private readonly IPlanetDto _planetDto;
    public PlanetsController(IPlanetDto planetDto)
    {
        _planetDto = planetDto;
    }

    [HttpPost("Ekle")]
    public async Task<IActionResult> Add([FromBody] CreatePlanetRequest createRequest)
    {
        var response = await _planetDto.AddAsync(createRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPut("Güncelle")]
    public async Task<IActionResult> Update([FromBody] UpdatePlanetRequest updateRequest)
    {
        var response = await _planetDto.UpdateAsync(updateRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpDelete("Sil{id}")]
    public async Task<IActionResult> Delete(DeletePlanetRequest deleteRequest)
    {
        var response = await _planetDto.DeleteAsync(deleteRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpGet("Listele")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _planetDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _planetDto.GetAsync(id);
        return Ok(response);
    }
}
