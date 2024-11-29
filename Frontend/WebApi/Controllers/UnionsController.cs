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
    public async Task<IActionResult> Add([FromBody] CreateUnionRequest createRequest)
    {
        var response = await _unionDto.AddAsync(createRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPut("Güncelle")]
    public async Task<IActionResult> Update([FromBody] UpdateUnionRequest updateRequest)
    {
        var response = await _unionDto.UpdateAsync(updateRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpDelete("Sil{id}")]
    public async Task<IActionResult> Delete(DeleteUnionRequest deleteRequest)
    {
        var response = await _unionDto.DeleteAsync(deleteRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpGet("Listele")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _unionDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _unionDto.GetAsync(id);
        return Ok(response);
    }
}
