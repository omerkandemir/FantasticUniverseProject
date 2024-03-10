using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Character;
using NLayer.Dto.Responses.Character;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly ICharacterService _characterService;
    public CharactersController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpPost("Ekle")]
    public IActionResult Add(CreateCharacterRequest createdRequest)
    {
        CreatedCharacterResponse createdResponse = _characterService.Add(createdRequest);
        return Ok(createdResponse);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateCharacterRequest updatedRequest)
    {
        UpdatedCharacterResponse updatedResponse = _characterService.Update(updatedRequest);
        return Ok(updatedResponse);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteCharacterRequest deleteRequest)
    {
        DeletedCharacterResponse deletedResponse = _characterService.Delete(deleteRequest);
        return Ok(deletedResponse);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        return Ok(_characterService.GetAll());
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        return Ok(_characterService.Get(Id));
    }
}
