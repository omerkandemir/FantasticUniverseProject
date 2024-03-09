using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Adventure;
using NLayer.Dto.Responses.Adventure;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdventuresController : ControllerBase
{
    IAdventureService _adventureService;
    public AdventuresController(IAdventureService adventureService)
    {
        _adventureService = adventureService;
    }
    [HttpPost("Ekle")]
    public IActionResult Add(CreateAdventureRequest createAdventureRequest)
    {
        CreatedAdventureResponse createdAdventureResponse = _adventureService.Add(createAdventureRequest);
        return Ok(createdAdventureResponse);
    }
    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateAdventureRequest updateAdventureRequest)
    {
        UpdatedAdventureResponse updatedAdventureResponse = _adventureService.Update(updateAdventureRequest);
        return Ok(updatedAdventureResponse);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteAdventureRequest deleteAdventureRequest)
    {
        DeletedAdventureResponse deletedAdventureResponse = _adventureService.Delete(deleteAdventureRequest);
        return Ok(deletedAdventureResponse);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        return Ok(_adventureService.GetAll());
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        return Ok(_adventureService.Get(Id));
    }
}
