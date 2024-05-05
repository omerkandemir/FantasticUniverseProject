using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.Star;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StarsController : ControllerBase
{
    private readonly IStarDto _starDto;
    public StarsController(IStarDto starDto)
    {
        _starDto = starDto;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateStarRequest createRequest)
    {
        var response = _starDto.Add(createRequest);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateStarRequest updateRequest)
    {
        var response = _starDto.Update(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteStarRequest deleteRequest)
    {
        var response = _starDto.Delete(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _starDto.GetAll();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _starDto.Get(Id);
        return Ok(response);
    }
}
