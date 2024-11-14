﻿using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.Universe;

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
    [HttpPost("Ekle")]
    public IActionResult Add(CreateUniverseRequest createRequest)
    {
        var response = _universeDto.AddAsync(createRequest);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateUniverseRequest updateRequest)
    {
        var response = _universeDto.UpdateAsync(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteUniverseRequest deleteRequest)
    {
        var response = _universeDto.DeleteAsync(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _universeDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _universeDto.GetAsync(Id);
        return Ok(response);
    }
}
