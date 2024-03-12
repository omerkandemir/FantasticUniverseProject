using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.UnionCharacter;
using NLayer.Dto.Responses.UnionCharacter;
using NLayer.Entities.Concretes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UnionCharactersController : ControllerBase
{
    private readonly IUnionCharacterService _unionCharacterService;
    private readonly IMapper _mapper;
    public UnionCharactersController(IUnionCharacterService unionCharacterService, IMapper mapper)
    {
        _unionCharacterService = unionCharacterService;
        _mapper = mapper;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateUnionCharacterRequest createRequest)
    {
        var value = _mapper.Map<UnionCharacter>(createRequest);
        _unionCharacterService.Add(value);
        var response = _mapper.Map<CreatedUnionCharacterResponse>(value);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateUnionCharacterRequest updateRequest)
    {
        var value = _mapper.Map<UnionCharacter>(updateRequest);
        _unionCharacterService.Update(value);
        var response = _mapper.Map<UpdatedUnionCharacterResponse>(value);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteUnionCharacterRequest deleteRequest)
    {
        var value = _mapper.Map<UnionCharacter>(deleteRequest);
        _unionCharacterService.Delete(value);
        var response = _mapper.Map<DeletedUnionCharacterResponse>(value);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var value = _unionCharacterService.GetAll();
        var response = _mapper.Map<List<GetAllUnionCharacterResponse>>(value);
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var value = _unionCharacterService.Get(Id);
        var response = _mapper.Map<GetAllUnionCharacterResponse>(value);
        return Ok(response);
    }
}
