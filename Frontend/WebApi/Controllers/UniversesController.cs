using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Universe;
using NLayer.Dto.Responses.Universe;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversesController : ControllerBase
{
    IUniverseService _universeService;
    public UniversesController(IUniverseService universeService)
    {
        _universeService = universeService;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateUniverseRequest createdRequest)
    {
        CreatedUniverseResponse createdResponse = _universeService.Add(createdRequest);
        return Ok(createdResponse);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateUniverseRequest updatedRequest)
    {
        UpdatedUniverseResponse updatedResponse = _universeService.Update(updatedRequest);
        return Ok(updatedResponse);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteUniverseRequest deleteRequest)
    {
        DeletedUniverseResponse deletedResponse = _universeService.Delete(deleteRequest);
        return Ok(deletedResponse);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        return Ok(_universeService.GetAll());
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        return Ok(_universeService.Get(Id));
    }
}
