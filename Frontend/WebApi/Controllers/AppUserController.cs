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
        var response = _appUserDto.UpdateAsync(updateRequest);
        return Ok(response);
    }
    [HttpDelete("Sil")]
    public IActionResult Delete(DeleteAppUserRequest deleteRequest)
    {
        var response = _appUserDto.DeleteAsync(deleteRequest);
        return Ok(response);
    }

    [HttpGet("Listele")]
    public IActionResult GetAll()
    {
        var response = _appUserDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir")]
    public IActionResult Get(int Id = 1)
    {
        var response = _appUserDto.GetAsync(Id);
        return Ok(response);
    }
}