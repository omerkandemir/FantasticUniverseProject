using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.Adventure;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdventuresController : ControllerBase
{
    private readonly IAdventureDto _adventureDto;
    public AdventuresController(IAdventureDto adventureDto)
    {
        _adventureDto = adventureDto;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateAdventureRequest createRequest)
    {
        var response = _adventureDto.Add(createRequest);
        return Ok(response);
    }
    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateAdventureRequest updateRequest)
    {
        var response = _adventureDto.Update(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteAdventureRequest deleteRequest)
    {
        var response = _adventureDto.Delete(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _adventureDto.GetAll();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _adventureDto.Get(Id);
        return Ok(response);
    }
}
