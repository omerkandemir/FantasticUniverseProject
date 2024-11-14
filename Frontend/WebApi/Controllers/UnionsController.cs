using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.Union;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UnionsController : ControllerBase
{
    private readonly IUnionDto _unionDto;
    public UnionsController(IUnionDto unionDto)
    {
        _unionDto = unionDto;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateUnionRequest createRequest)
    {
        var response = _unionDto.AddAsync(createRequest);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateUnionRequest updateRequest)
    {
        var response = _unionDto.UpdateAsync(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteUnionRequest deleteRequest)
    {
        var response = _unionDto.DeleteAsync(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _unionDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _unionDto.GetAsync(Id);
        return Ok(response);
    }
}
