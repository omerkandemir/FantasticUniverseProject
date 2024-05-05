using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.UnionCharacter;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UnionCharactersController : ControllerBase
{
    private readonly IUnionCharacterDto _unionCharacterDto;
    public UnionCharactersController(IUnionCharacterDto unionCharacterDto)
    {
        _unionCharacterDto = unionCharacterDto;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateUnionCharacterRequest createRequest)
    {
        var response = _unionCharacterDto.Add(createRequest);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateUnionCharacterRequest updateRequest)
    {
        var response = _unionCharacterDto.Update(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteUnionCharacterRequest deleteRequest)
    {
        var response = _unionCharacterDto.Delete(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _unionCharacterDto.GetAll();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _unionCharacterDto.Get(Id);
        return Ok(response);
    }
}
