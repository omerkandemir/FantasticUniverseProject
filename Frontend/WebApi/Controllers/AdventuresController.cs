using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.Adventure;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdventuresController : ControllerBase
{
    private readonly IAdventureDto _adventureDto;
    public AdventuresController(IAdventureDto adventureDto)
    {
        _adventureDto = adventureDto;
    }
    [HttpPost("Ekle")]
    public async Task<IActionResult> Add([FromBody] CreateAdventureRequest createRequest)
    {
        var response = await _adventureDto.AddAsync(createRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpPut("Güncelle")]
    public async Task<IActionResult> Update([FromBody] UpdateAdventureRequest updateRequest)
    {
        var response = await _adventureDto.UpdateAsync(updateRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpDelete("Sil{id}")]
    public async Task<IActionResult> Delete(DeleteAdventureRequest deleteRequest)
    {
        var response = await _adventureDto.DeleteAsync(deleteRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpGet("Listele")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _adventureDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _adventureDto.GetAsync(id);
        return Ok(response);
    }
}
