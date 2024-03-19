using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Universe;
using NLayer.Dto.Responses.Universe;
using NLayer.Entities.Concretes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversesController : ControllerBase
{
    private readonly IUniverseService _universeService;
    private readonly IMapper _mapper;
    public UniversesController(IUniverseService universeService, IMapper mapper)
    {
        _universeService = universeService;
        _mapper = mapper;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateUniverseRequest createRequest)
    {
        var value = _mapper.Map<Universe>(createRequest);
        _universeService.Add(value);
        var response = _mapper.Map<CreatedUniverseResponse>(value);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateUniverseRequest updateRequest)
    {
        var value = _mapper.Map<Universe>(updateRequest);
        _universeService.Update(value);
        var response = _mapper.Map<UpdatedUniverseResponse>(value);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteUniverseRequest deleteRequest)
    {
        var value = _mapper.Map<Universe>(deleteRequest);
        _universeService.Delete(value);
        var response = _mapper.Map<DeletedUniverseResponse>(value);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var value = _universeService.GetAll();
        var response = _mapper.Map<List<GetAllUniverseResponse>>(value.Data);
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var value = _universeService.Get(Id);
        var response = _mapper.Map<GetAllUniverseResponse>(value.Data);
        return Ok(response);
    }
}
