using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.Species;

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
        var response = _speciesDto.AddAsync(createRequest);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateSpeciesRequest updateRequest)
    {
        var response = _speciesDto.UpdateAsync(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteSpeciesRequest deleteRequest)
    {
        var response = _speciesDto.DeleteAsync(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _speciesDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _speciesDto.GetAsync(Id);
        return Ok(response);
    }
}
