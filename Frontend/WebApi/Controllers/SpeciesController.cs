using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Species;
using NLayer.Dto.Responses.Species;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpeciesController : ControllerBase
{
    ISpeciesService _speciesService;
    public SpeciesController(ISpeciesService speciesService)
    {
        _speciesService = speciesService;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateSpeciesRequest createdRequest)
    {
        CreatedSpeciesResponse createdResponse = _speciesService.Add(createdRequest);
        return Ok(createdResponse);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateSpeciesRequest updatedRequest)
    {
        UpdatedSpeciesResponse updatedResponse = _speciesService.Update(updatedRequest);
        return Ok(updatedResponse);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteSpeciesRequest deleteRequest)
    {
        DeletedSpeciesResponse deletedResponse = _speciesService.Delete(deleteRequest);
        return Ok(deletedResponse);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        return Ok(_speciesService.GetAll());
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        return Ok(_speciesService.Get(Id));
    }
}
