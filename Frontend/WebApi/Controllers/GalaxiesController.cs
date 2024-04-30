using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Dto.Requests.Galaxy;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GalaxiesController : ControllerBase
{
    private readonly IGalaxyDto _galaxyDto;
    public GalaxiesController(IGalaxyDto galaxyDto)
    {
        _galaxyDto = galaxyDto;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateGalaxyRequest createRequest)
    {
        var response = _galaxyDto.Add(createRequest);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateGalaxyRequest updateRequest)
    {
        var response = _galaxyDto.Update(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteGalaxyRequest deleteRequest)
    {
        var response = _galaxyDto.Delete(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _galaxyDto.GetAll();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _galaxyDto.Get(Id);
        return Ok(response);
    }
}
