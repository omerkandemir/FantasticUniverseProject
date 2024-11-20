using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.UnionCharacter;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UnionCharactersController : ControllerBase
{
    private readonly IUnionCharacterDto _unionCharacterDto;
    public UnionCharactersController(IUnionCharacterDto unionCharacterDto)
    {
        _unionCharacterDto = unionCharacterDto;
    }
    [HttpPost("Ekle")]
    public async Task<IActionResult> Add([FromBody] CreateUnionCharacterRequest createRequest)
    {
        var response = await _unionCharacterDto.AddAsync(createRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPut("Güncelle")]
    public async Task<IActionResult> Update([FromBody] UpdateUnionCharacterRequest updateRequest)
    {
        var response = await _unionCharacterDto.UpdateAsync(updateRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpDelete("Sil{id}")]
    public async Task<IActionResult> Delete(DeleteUnionCharacterRequest deleteRequest)
    {
        var response = await _unionCharacterDto.DeleteAsync(deleteRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpGet("Listele")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _unionCharacterDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _unionCharacterDto.GetAsync(id);
        return Ok(response);
    }
}
