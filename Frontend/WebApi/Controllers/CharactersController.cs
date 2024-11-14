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
    public IActionResult Add(CreateCharacterRequest createRequest)
    {
        var response = _characterDto.AddAsync(createRequest);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateCharacterRequest updateRequest)
    {
        var response = _characterDto.UpdateAsync(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteCharacterRequest deleteRequest)
    {
        var response = _characterDto.DeleteAsync(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _characterDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _characterDto.GetAsync(Id);
        return Ok(response);
    }
}
