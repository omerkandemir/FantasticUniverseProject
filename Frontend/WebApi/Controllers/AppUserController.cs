using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AppUser;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppUserController : ControllerBase
{
    private readonly IAppUserDto _appUserDto;

    public AppUserController(IAppUserDto appUserDto)
    {
        _appUserDto = appUserDto;
    }

    [HttpPost("Ekle")]
    public IActionResult Add(CreateAppUserRequest createRequest)
    {
        var response = _appUserDto.AddAsync(createRequest);
        return Ok(response);
    }
    [HttpPost("Güncelle")]
    public IActionResult Update(UpdateAppUserRequest updateRequest)
    {
        var response = _appUserDto.Update(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteAppUserRequest deleteRequest)
    {
        var response = _appUserDto.Delete(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _appUserDto.GetAll();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _appUserDto.Get(Id);
        return Ok(response);
    }
}