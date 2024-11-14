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
    public IActionResult Add(CreateAbilityCharacterRequest createRequest)
    {
        var response = _abilityCharacterDto.AddAsync(createRequest);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateAbilityCharacterRequest updateRequest)
    {
        var response = _abilityCharacterDto.UpdateAsync(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteAbilityCharacterRequest deleteRequest)
    {
        var response = _abilityCharacterDto.DeleteAsync(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _abilityCharacterDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _abilityCharacterDto.GetAsync(Id);
        return Ok(response);
    }
}
