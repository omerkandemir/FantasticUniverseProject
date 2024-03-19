using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Star;
using NLayer.Dto.Responses.Star;
using NLayer.Entities.Concretes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StarsController : ControllerBase
{
    private readonly IStarService _starService;
    private readonly IMapper _mapper;
    public StarsController(IStarService starService, IMapper mapper)
    {
        _starService = starService;
        _mapper = mapper;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateStarRequest createRequest)
    {
        var value = _mapper.Map<Star>(createRequest);
        _starService.Add(value);
        var response = _mapper.Map<CreatedStarResponse>(value);
        return Ok(response);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateStarRequest updateRequest)
    {
        var value = _mapper.Map<Star>(updateRequest);
        _starService.Update(value);
        var response = _mapper.Map<UpdatedStarResponse>(value);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteStarRequest deleteRequest)
    {
        var value = _mapper.Map<Star>(deleteRequest);
        _starService.Delete(value);
        var response = _mapper.Map<DeletedStarResponse>(value);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var value = _starService.GetAll();
        var response = _mapper.Map<List<GetAllStarResponse>>(value.Data);
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var value = _starService.Get(Id);
        var response = _mapper.Map<GetAllStarResponse>(value.Data);
        return Ok(response);
    }
}
