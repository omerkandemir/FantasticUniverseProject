using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Planet;
using NLayer.Dto.Responses.Planet;
using NLayer.Entities.Concretes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlanetsController : ControllerBase
{
    private readonly IPlanetService _planetService;
    private readonly IMapper _mapper;
    public PlanetsController(IPlanetService planetService,IMapper mapper)
    {
        _planetService = planetService;
        _mapper = mapper;
    }

    [HttpPost("Ekle")]
    public IActionResult Add(CreatePlanetRequest createRequest)
    {
        var value = _mapper.Map<Planet>(createRequest);
        _planetService.Add(value);
        var response = _mapper.Map<CreatedPlanetResponse>(value);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdatePlanetRequest updateRequest)
    {
        var value = _mapper.Map<Planet>(updateRequest);
        _planetService.Update(value);
        var response = _mapper.Map<UpdatedPlanetResponse>(value);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeletePlanetRequest deleteRequest)
    {
        var value = _mapper.Map<Planet>(deleteRequest);
        _planetService.Delete(value);
        var response = _mapper.Map<DeletedPlanetResponse>(value);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var value = _planetService.GetAll();
        var response = _mapper.Map<List<GetAllPlanetResponse>>(value);
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var value = _planetService.Get(Id);
        var response = _mapper.Map<GetAllPlanetResponse>(value);
        return Ok(response);
    }
}
