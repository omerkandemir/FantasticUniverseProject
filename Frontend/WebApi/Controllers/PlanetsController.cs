using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Planet;
using NLayer.Dto.Responses.Planet;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlanetsController : ControllerBase
{
    IPlanetService _planetService;
    public PlanetsController(IPlanetService planetService)
    {
        _planetService = planetService;
    }

    [HttpPost("Ekle")]
    public IActionResult Add(CreatePlanetRequest createdRequest)
    {
        CreatedPlanetResponse createdResponse = _planetService.Add(createdRequest);
        return Ok(createdResponse);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdatePlanetRequest updatedRequest)
    {
        UpdatedPlanetResponse updatedResponse = _planetService.Update(updatedRequest);
        return Ok(updatedResponse);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeletePlanetRequest deleteRequest)
    {
        DeletedPlanetResponse deletedResponse = _planetService.Delete(deleteRequest);
        return Ok(deletedResponse);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        return Ok(_planetService.GetAll());
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        return Ok(_planetService.Get(Id));
    }
}
