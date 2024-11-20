using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AbilityCharacter;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AbilityCharactersController : ControllerBase
{
    private readonly IAbilityCharacterDto _abilityCharacterDto;
    public AbilityCharactersController(IAbilityCharacterDto abilityCharacterDto)
    {
        _abilityCharacterDto = abilityCharacterDto;
    }
    [HttpPost("Ekle")]
    public async Task<IActionResult> Add([FromBody] CreateAbilityCharacterRequest createRequest)
    {
        var response = await _abilityCharacterDto.AddAsync(createRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPut("Güncelle")]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityCharacterRequest updateRequest)
    {
        var response = await _abilityCharacterDto.UpdateAsync(updateRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpDelete("Sil{id}")]
    public async Task<IActionResult> Delete(DeleteAbilityCharacterRequest deleteRequest)
    {
        var response = await _abilityCharacterDto.DeleteAsync(deleteRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpGet("Listele")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _abilityCharacterDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _abilityCharacterDto.GetAsync(id);
        return Ok(response);
    }
}
