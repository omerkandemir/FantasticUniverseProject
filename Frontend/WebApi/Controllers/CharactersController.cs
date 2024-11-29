using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.Character;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly ICharacterDto _characterDto;
    public CharactersController(ICharacterDto characterDto)
    {
        _characterDto = characterDto;
    }

    [HttpPost("Ekle")]
    public async Task<IActionResult> Add([FromBody] CreateCharacterRequest createRequest)
    {
        var response = await _characterDto.AddAsync(createRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPut("Güncelle")]
    public async Task<IActionResult> Update([FromBody] UpdateCharacterRequest updateRequest)
    {
        var response = await _characterDto.UpdateAsync(updateRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpDelete("Sil{id}")]
    public async Task<IActionResult> Delete(DeleteCharacterRequest deleteRequest)
    {
        var response = await _characterDto.DeleteAsync(deleteRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpGet("Listele")]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _characterDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _characterDto.GetAsync(id);
        return Ok(response);
    }
}
