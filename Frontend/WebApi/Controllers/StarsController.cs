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
        var response = _starDto.AddAsync(createRequest);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateStarRequest updateRequest)
    {
        var response = _starDto.UpdateAsync(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteStarRequest deleteRequest)
    {
        var response = _starDto.DeleteAsync(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _starDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _starDto.GetAsync(Id);
        return Ok(response);
    }
}
