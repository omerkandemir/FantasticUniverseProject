using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Star;
using NLayer.Dto.Responses.Star;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StarsController : ControllerBase
{
    IStarService _starService;
    public StarsController(IStarService starService)
    {
            _starService = starService;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateStarRequest createdRequest)
    {
        CreatedStarResponse createdResponse = _starService.Add(createdRequest);
        return Ok(createdResponse);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateStarRequest updatedRequest)
    {
        UpdatedStarResponse updatedResponse = _starService.Update(updatedRequest);
        return Ok(updatedResponse);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteStarRequest deleteRequest)
    {
        DeletedStarResponse deletedResponse = _starService.Delete(deleteRequest);
        return Ok(deletedResponse);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        return Ok(_starService.GetAll());
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        return Ok(_starService.Get(Id));
    }
}
