using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.AdventureCharacter;
using NLayer.Dto.Responses.AdventureCharacter;
using NLayer.Entities.Concretes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdventureCharactersController : ControllerBase
{
    private readonly IAdventureCharacterService _adventureCharacterService;
    private readonly IMapper _mapper;
    public AdventureCharactersController(IAdventureCharacterService adventureCharacterService, IMapper mapper)
    {
        _adventureCharacterService = adventureCharacterService;
        _mapper = mapper;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateAdventureCharacterRequest createRequest)
    {
        var value = _mapper.Map<AdventureCharacter>(createRequest);
        _adventureCharacterService.Add(value);
        var response = _mapper.Map<CreatedAdventureCharacterResponse>(value);
        return Ok(response);
    }
    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateAdventureCharacterRequest updateRequest)
    {
        var value = _mapper.Map<AdventureCharacter>(updateRequest);
        _adventureCharacterService.Update(value);
        var response = _mapper.Map<UpdatedAdventureCharacterResponse>(value);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteAdventureCharacterRequest deleteRequest)
    {
        var value = _mapper.Map<AdventureCharacter>(deleteRequest);
        _adventureCharacterService.Delete(value);
        var response = _mapper.Map<DeletedAdventureCharacterResponse>(value);
        return Ok(response);
    }
    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var value = _adventureCharacterService.GetAll();
        var response = _mapper.Map<List<GetAllAdventureCharacterResponse>>(value);
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var value = _adventureCharacterService.Get(Id);
        var response = _mapper.Map<GetAllAdventureCharacterResponse>(value);
        return Ok(response);
    }
}
