using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Dto.Requests.AbilityCharacter;

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
        var response = _abilityCharacterDto.Add(createRequest);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateAbilityCharacterRequest updateRequest)
    {
        var response = _abilityCharacterDto.Update(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteAbilityCharacterRequest deleteRequest)
    {
        var response = _abilityCharacterDto.Delete(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _abilityCharacterDto.GetAll();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _abilityCharacterDto.Get(Id);
        return Ok(response);
    }
}
