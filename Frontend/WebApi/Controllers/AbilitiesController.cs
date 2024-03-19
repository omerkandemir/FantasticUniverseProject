using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Requests.Ability;
using NLayer.Dto.Responses.Ability;
using NLayer.Business.Abstracts;
using NLayer.Entities.Concretes;
using AutoMapper;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AbilitiesController : ControllerBase
{
    private readonly IAbilityService _abilityService;
    private readonly IMapper _mapper;
    public AbilitiesController(IAbilityService abilityService, IMapper mapper)
    {
        _abilityService = abilityService;
        _mapper = mapper;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateAbilityRequest createRequest)
    {
        var value = _mapper.Map<Ability>(createRequest);
        _abilityService.Add(value);
        var response = _mapper.Map<CreatedAbilityResponse>(value);
        return Ok(response);
    }
    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateAbilityRequest updateRequest)
    {
        var value = _mapper.Map<Ability>(updateRequest);
        _abilityService.Update(value);
        var response = _mapper.Map<UpdatedAbilityResponse>(value);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteAbilityRequest deleteRequest)
    {
        var value = _mapper.Map<Ability>(deleteRequest);
        _abilityService.Delete(value);
        var response = _mapper.Map<DeletedAbilityResponse>(value);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var value = _abilityService.GetAll();
        var response = _mapper.Map<List<GetAllAbilityResponse>>(value.Data);
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var value = _abilityService.Get(Id);
        var response = _mapper.Map<GetAllAbilityResponse>(value.Data);
        return Ok(response);
    }
}
