using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.Ability;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AbilitiesController : ControllerBase
{
    private readonly IAbilityDto _abilityDto;
    public AbilitiesController(IAbilityDto abilityDto)
    {
        _abilityDto = abilityDto;
    }
    [HttpPost("Ekle")]
    public async Task<IActionResult> Add([FromBody] CreateAbilityRequest createRequest)
    {
        var response = await _abilityDto.AddAsync(createRequest);
        if (response.Success)
            return Ok(response);

        return BadRequest(response);
    }
    [HttpPut("Güncelle")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAbilityRequest updateRequest)
    {
        var response = await _abilityDto.UpdateAsync(updateRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpDelete("Sil{id}")]
    public async Task<IActionResult> Delete(DeleteAbilityRequest deleteRequest)
    {
        var response = await _abilityDto.DeleteAsync(deleteRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpGet("Listele")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _abilityDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _abilityDto.GetAsync(id);
        return Ok(response);
    }
}
