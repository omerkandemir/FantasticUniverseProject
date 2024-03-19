using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Species;
using NLayer.Dto.Responses.Species;
using NLayer.Entities.Concretes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpeciesController : ControllerBase
{
    private readonly ISpeciesService _speciesService;
    private readonly IMapper _mapper;
    public SpeciesController(ISpeciesService speciesService, IMapper mapper)
    {
        _speciesService = speciesService;
        _mapper = mapper;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateSpeciesRequest createRequest)
    {
        var value = _mapper.Map<Species>(createRequest);
        _speciesService.Add(value);
        var response = _mapper.Map<CreatedSpeciesResponse>(value);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateSpeciesRequest updateRequest)
    {
        var value = _mapper.Map<Species>(updateRequest);
        _speciesService.Update(value);
        var response = _mapper.Map<UpdatedSpeciesResponse>(value);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteSpeciesRequest deleteRequest)
    {
        var value = _mapper.Map<Species>(deleteRequest);
        _speciesService.Delete(value);
        var response = _mapper.Map<DeletedSpeciesResponse>(value);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var value = _speciesService.GetAll();
        var response = _mapper.Map<List<GetAllSpeciesResponse>>(value.Data);
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var value = _speciesService.Get(Id);
        var response = _mapper.Map<GetAllSpeciesResponse>(value.Data);
        return Ok(response);
    }
}
