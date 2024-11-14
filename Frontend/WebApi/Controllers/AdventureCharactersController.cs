﻿using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AdventureCharacter;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdventureCharactersController : ControllerBase
{
    private readonly IAdventureCharacterDto _adventureCharacterDto;
    public AdventureCharactersController(IAdventureCharacterDto adventureCharacterDto)
    {
        _adventureCharacterDto = adventureCharacterDto;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateAdventureCharacterRequest createRequest)
    {
        var response = _adventureCharacterDto.AddAsync(createRequest);
        return Ok(response);
    }
    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateAdventureCharacterRequest updateRequest)
    {
        var response = _adventureCharacterDto.UpdateAsync(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteAdventureCharacterRequest deleteRequest)
    {
        var response = _adventureCharacterDto.DeleteAsync(deleteRequest);
        return Ok(response);
    }
    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _adventureCharacterDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _adventureCharacterDto.GetAsync(Id);
        return Ok(response);
    }
}
