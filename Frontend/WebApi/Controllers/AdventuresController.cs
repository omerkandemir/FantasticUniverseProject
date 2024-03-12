using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Adventure;
using NLayer.Dto.Responses.Adventure;
using NLayer.Entities.Concretes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdventuresController : ControllerBase
{
    private readonly IAdventureService _adventureService;
    private readonly IMapper _mapper;
    public AdventuresController(IAdventureService adventureService, IMapper mapper)
    {
        _adventureService = adventureService;
        _mapper = mapper;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateAdventureRequest createRequest)
    {
        var value = _mapper.Map<Adventure>(createRequest);
        _adventureService.Add(value);
        var response = _mapper.Map<CreatedAdventureResponse>(value);
        return Ok(response);
    }
    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateAdventureRequest updateRequest)
    {
        var value = _mapper.Map<Adventure>(updateRequest);
        _adventureService.Update(value);
        var response = _mapper.Map<UpdatedAdventureResponse>(value);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteAdventureRequest deleteRequest)
    {
        var value = _mapper.Map<Adventure>(deleteRequest);
        _adventureService.Delete(value);
        var response = _mapper.Map<DeletedAdventureResponse>(value);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var value = _adventureService.GetAll();
        var response = _mapper.Map<List<GetAllAdventureResponse>>(value);
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var value = _adventureService.Get(Id);
        var response = _mapper.Map<GetAllAdventureResponse>(value);
        return Ok(response);
    }
}
