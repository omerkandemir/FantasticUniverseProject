using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.Planet;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlanetsController : ControllerBase
{
    private readonly IPlanetDto _planetDto;
    public PlanetsController(IPlanetDto planetDto)
    {
        _planetDto = planetDto;
    }

    [HttpPost("Ekle")]
    public IActionResult Add(CreatePlanetRequest createRequest)
    {
        var response = _planetDto.AddAsync(createRequest);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdatePlanetRequest updateRequest)
    {
        var response = _planetDto.UpdateAsync(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeletePlanetRequest deleteRequest)
    {
        var response = _planetDto.DeleteAsync(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _planetDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _planetDto.GetAsync(Id);
        return Ok(response);
    }
}
