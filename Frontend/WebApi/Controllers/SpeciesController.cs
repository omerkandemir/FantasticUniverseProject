using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.Species;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpeciesController : ControllerBase
{
    private readonly ISpeciesDto _speciesDto;
    public SpeciesController(ISpeciesDto speciesDto)
    {
        _speciesDto = speciesDto;
    }
    [HttpPost("Ekle")]
    public async Task<IActionResult> Add([FromBody] CreateSpeciesRequest createRequest)
    {
        var response = await _speciesDto.AddAsync(createRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPut("Güncelle")]
    public async Task<IActionResult> Update([FromBody] UpdateSpeciesRequest updateRequest)
    {
        var response = await _speciesDto.UpdateAsync(updateRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpDelete("Sil{id}")]
    public async Task<IActionResult> Delete(DeleteSpeciesRequest deleteRequest)
    {
        var response = await _speciesDto.DeleteAsync(deleteRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpGet("Listele")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _speciesDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _speciesDto.GetAsync(id);
        return Ok(response);
    }
}
