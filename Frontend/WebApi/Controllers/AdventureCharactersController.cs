using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AdventureCharacter;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdventureCharactersController : ControllerBase
{
    private readonly IAdventureCharacterDto _adventureCharacterDto;
    public AdventureCharactersController(IAdventureCharacterDto adventureCharacterDto)
    {
        _adventureCharacterDto = adventureCharacterDto;
    }
    [HttpPost("Ekle")]
    public async Task<IActionResult> Add([FromBody] CreateAdventureCharacterRequest createRequest)
    {
        var response = await _adventureCharacterDto.AddAsync(createRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpPut("Güncelle")]
    public async Task<IActionResult> Update([FromBody] UpdateAdventureCharacterRequest updateRequest)
    {
        var response = await _adventureCharacterDto.UpdateAsync(updateRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpDelete("Sil{id}")]
    public async Task<IActionResult> Delete(DeleteAdventureCharacterRequest deleteRequest)
    {
        var response = await _adventureCharacterDto.DeleteAsync(deleteRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpGet("Listele")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _adventureCharacterDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _adventureCharacterDto.GetAsync(id);
        return Ok(response);
    }
}
