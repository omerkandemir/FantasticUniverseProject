using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Union;
using NLayer.Dto.Responses.Union;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UnionsController : ControllerBase
{
    IUnionService _unionService;
    public UnionsController(IUnionService unionService)
    {
        _unionService = unionService;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateUnionRequest createdRequest)
    {
        CreatedUnionResponse createdResponse = _unionService.Add(createdRequest);
        return Ok(createdResponse);
    }

    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateUnionRequest updatedRequest)
    {
        UpdatedUnionResponse updatedResponse = _unionService.Update(updatedRequest);
        return Ok(updatedResponse);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteUnionRequest deleteRequest)
    {
        DeletedUnionResponse deletedResponse = _unionService.Delete(deleteRequest);
        return Ok(deletedResponse);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        return Ok(_unionService.GetAll());
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        return Ok(_unionService.Get(Id));
    }
}
