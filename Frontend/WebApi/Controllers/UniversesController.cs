using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.Universe;
using NLayer.Mapper.Responses.Concrete.Universe;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversesController : ControllerBase
{
    private readonly IUniverseDto _universeDto;
    public UniversesController(IUniverseDto universeDto)
    {
        _universeDto = universeDto;
    }
    [HttpPost("CreateUniverseAsync")]
    public async Task<IActionResult> CreateUniverseAsync([FromBody] CreateUniverseRequest createRequest)
    {
        var response = await _universeDto.CreateUniverseAsync(createRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPut("Güncelle")]
    public async Task<IActionResult> Update([FromBody] UpdateUniverseRequest updateRequest)
    {
        var response = await _universeDto.UpdateAsync(updateRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpDelete("Sil{id}")]
    public async Task<IActionResult> Delete(DeleteUniverseRequest deleteRequest)
    {
        var response = await _universeDto.DeleteAsync(deleteRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpGet("Listele")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _universeDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _universeDto.GetAsync(id);
        return Ok(response);
    }

    [HttpGet("GetUserUniverses/{userId}")]
    public async Task<IActionResult> GetUserUniverses(int userId)
    {
        var response = (await _universeDto.GetUserUniversesAsync(userId)).Responses.ToList();
        var universeList = response.Cast<GetUniverseResponse>().ToList(); 
        if (universeList != null)
            return Ok(universeList);
        return NotFound("No universes found for the user.");
    }

    [HttpGet("GetUniverseDetails/{id}")]
    public async Task<IActionResult> GetUniverseDetails(int id)
    {
        var response = await _universeDto.GetUniverseDetailAsync(id);
        if (response != null)
            return Ok(response);
        return NotFound("Universe not found.");
    }
}
