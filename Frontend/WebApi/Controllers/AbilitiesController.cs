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
    public IActionResult Add(CreateAbilityRequest createRequest)
    {
        var response = _abilityDto.AddAsync(createRequest);
        return Ok(response);
    }
    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateAbilityRequest updateRequest)
    {
        var response = _abilityDto.UpdateAsync(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteAbilityRequest deleteRequest)
    {
        var response = _abilityDto.DeleteAsync(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _abilityDto.GetAllAsync();    
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _abilityDto.GetAsync(Id);
        return Ok(response);
    }
}
