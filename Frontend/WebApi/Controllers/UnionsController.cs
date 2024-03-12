using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Union;
using NLayer.Dto.Responses.Union;
using NLayer.Entities.Concretes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UnionsController : ControllerBase
{
    private readonly IUnionService _unionService;
    private readonly IMapper _mapper;
    public UnionsController(IUnionService unionService, IMapper mapper)
    {
        _unionService = unionService;
        _mapper = mapper;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateUnionRequest createRequest)
    {
        var value = _mapper.Map<Union>(createRequest);
        _unionService.Add(value);
        var response = _mapper.Map<CreatedUnionResponse>(value);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateUnionRequest updateRequest)
    {
        var value = _mapper.Map<Union>(updateRequest);
        _unionService.Update(value);
        var response = _mapper.Map<UpdatedUnionResponse>(value);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteUnionRequest deleteRequest)
    {
        var value = _mapper.Map<Union>(deleteRequest);
        _unionService.Delete(value);
        var response = _mapper.Map<DeletedUnionResponse>(value);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var value = _unionService.GetAll();
        var response = _mapper.Map<List<GetAllUnionResponse>>(value);
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var value = _unionService.Get(Id);
        var response = _mapper.Map<GetAllUnionResponse>(value);
        return Ok(response);
    }
}
