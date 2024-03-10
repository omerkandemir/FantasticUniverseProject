using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Galaxy;
using NLayer.Dto.Responses.Galaxy;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GalaxiesController : ControllerBase
{
    IGalaxyService _galaxyService;
    public GalaxiesController(IGalaxyService galaxyService)
    {
        _galaxyService = galaxyService;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateGalaxyRequest createdRequest)
    {
        CreatedGalaxyResponse createdResponse = _galaxyService.Add(createdRequest);
        return Ok(createdResponse);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateGalaxyRequest updatedRequest)
    {
        UpdatedGalaxyResponse updatedResponse = _galaxyService.Update(updatedRequest);
        return Ok(updatedResponse);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteGalaxyRequest deleteRequest)
    {
        DeletedGalaxyResponse deletedResponse = _galaxyService.Delete(deleteRequest);
        return Ok(deletedResponse);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        return Ok(_galaxyService.GetAll());
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        return Ok(_galaxyService.Get(Id));
    }
}
