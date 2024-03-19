using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Character;
using NLayer.Dto.Responses.Character;
using NLayer.Entities.Concretes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly ICharacterService _characterService;
    private readonly IMapper _mapper;
    public CharactersController(ICharacterService characterService, IMapper mapper)
    {
        _characterService = characterService;
        _mapper = mapper;
    }

    [HttpPost("Ekle")]
    public IActionResult Add(CreateCharacterRequest createRequest)
    {
        var value = _mapper.Map<Character>(createRequest);
        _characterService.Add(value);
        var response = _mapper.Map<CreatedCharacterResponse>(value);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateCharacterRequest updateRequest)
    {
        var value = _mapper.Map<Character>(updateRequest);
        _characterService.Update(value);
        var response = _mapper.Map<UpdatedCharacterResponse>(value);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteCharacterRequest deleteRequest)
    {
        var value = _mapper.Map<Character>(deleteRequest);
        _characterService.Delete(value);
        var response = _mapper.Map<DeletedCharacterResponse>(value);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var value = _characterService.GetAll();
        var response = _mapper.Map<List<GetAllCharacterResponse>>(value.Data);
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var value = _characterService.Get(Id);
        var response = _mapper.Map<GetAllCharacterResponse>(value.Data);
        return Ok(response);
    }
}
