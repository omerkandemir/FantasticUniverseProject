using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Galaxy;
using NLayer.Dto.Responses.Galaxy;
using NLayer.Entities.Concretes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GalaxiesController : ControllerBase
{
   private readonly IGalaxyService _galaxyService;
   private readonly IMapper _mapper;
    public GalaxiesController(IGalaxyService galaxyService, IMapper mapper)
    {
        _galaxyService = galaxyService;
        _mapper = mapper;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateGalaxyRequest createRequest)
    {
        var value = _mapper.Map<Galaxy>(createRequest);
        _galaxyService.Add(value);
        var response = _mapper.Map<CreatedGalaxyResponse>(value);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateGalaxyRequest updateRequest)
    {
        var value = _mapper.Map<Galaxy>(updateRequest);
        _galaxyService.Update(value);
        var response = _mapper.Map<UpdatedGalaxyResponse>(value);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteGalaxyRequest deleteRequest)
    {
        var value = _mapper.Map<Galaxy>(deleteRequest);
        _galaxyService.Delete(value);
        var response = _mapper.Map<DeletedGalaxyResponse>(value);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var value = _galaxyService.GetAll();
        var response = _mapper.Map<List<GetAllGalaxyResponse>>(value.Data);
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var value = _galaxyService.Get(Id);
        var response = _mapper.Map<GetAllGalaxyResponse>(value.Data);
        return Ok(response);
    }
}
