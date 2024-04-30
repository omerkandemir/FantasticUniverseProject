using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Dto.Requests.Species;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpeciesController : ControllerBase
{
    private readonly ISpeciesDto _speciesDto;
    public SpeciesController(ISpeciesDto speciesDto)
    {
        _speciesDto = speciesDto;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateSpeciesRequest createRequest)
    {
        var response = _speciesDto.Add(createRequest);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateSpeciesRequest updateRequest)
    {
        var response = _speciesDto.Update(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteSpeciesRequest deleteRequest)
    {
        var response = _speciesDto.Delete(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _speciesDto.GetAll();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _speciesDto.Get(Id);
        return Ok(response);
    }
}
