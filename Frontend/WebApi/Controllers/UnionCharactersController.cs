using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.UnionCharacter;
using NLayer.Dto.Responses.UnionCharacter;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UnionCharactersController : ControllerBase
{
    IUnionCharacterService _unionCharacterService;
    public UnionCharactersController(IUnionCharacterService unionCharacterService)
    {
        _unionCharacterService = unionCharacterService;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateUnionCharacterRequest createdRequest)
    {
        CreatedUnionCharacterResponse createdResponse = _unionCharacterService.Add(createdRequest);
        return Ok(createdResponse);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateUnionCharacterRequest updatedRequest)
    {
        UpdatedUnionCharacterResponse updatedResponse = _unionCharacterService.Update(updatedRequest);
        return Ok(updatedResponse);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteUnionCharacterRequest deleteRequest)
    {
        DeletedUnionCharacterResponse deletedResponse = _unionCharacterService.Delete(deleteRequest);
        return Ok(deletedResponse);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        return Ok(_unionCharacterService.GetAll());
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        return Ok(_unionCharacterService.Get(Id));
    }
}
