using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Dto.Requests.Universe;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversesController : ControllerBase
{
    private readonly IUniverseDto _universeDto;
    public UniversesController(IUniverseDto universeDto)
    {
        _universeDto = universeDto;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateUniverseRequest createRequest)
    {
        var response = _universeDto.Add(createRequest);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateUniverseRequest updateRequest)
    {
        var response = _universeDto.Update(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteUniverseRequest deleteRequest)
    {
        var response = _universeDto.Delete(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _universeDto.GetAll();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _universeDto.Get(Id);
        return Ok(response);
    }
}
