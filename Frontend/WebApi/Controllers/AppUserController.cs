using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Authentication;
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
    public async Task<IActionResult> Add([FromBody] CreateAppUserRequest createRequest)
    {
        var response = await _appUserDto.AddAsync(createRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpPut("Güncelle")]
    public async Task<IActionResult> Update([FromBody] UpdateAppUserRequest updateRequest)
    {
        var response = await _appUserDto.UpdateAsync(updateRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    [HttpDelete("Sil{id}")]
    public async Task<IActionResult> Delete(DeleteAppUserRequest deleteRequest)
    {
        var response = await _appUserDto.DeleteAsync(deleteRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpGet("Listele")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _appUserDto.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("Getir{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _appUserDto.GetAsync(id);
        return Ok(response);
    }

    [HttpPost("ConfirmMail")]
    public async Task<IActionResult> ConfirmMail([FromBody] ConfirmMailRequest confirmMailRequest)
    {
        var response = await _appUserDto.ConfirmMailAsync(confirmMailRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        var result = await _appUserDto.GetUserByNameAsync(loginRequest.Username);
        if (!result.Success)
            return BadRequest(result);

        var user = result as SuccessResponse<AppUser>;
        if (user?.Entity.EmailConfirmed == false)
            return Unauthorized("Email not confirmed");

        return Ok(user.Entity);
    }

    [HttpPut("ChangePassword")]
    public async Task<IActionResult> ChangePassword([FromBody] UpdateAppUserPasswordRequest updatePasswordRequest)
    {
        var response = await _appUserDto.UpdatePasswordAsync(updatePasswordRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPut("UpdateProfile")]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateAppUserRequest updateProfileRequest)
    {
        var response = await _appUserDto.UpdateAsync(updateProfileRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPut("ChangeProfileImage")]
    public async Task<IActionResult> ChangeProfileImage([FromBody] UpdateAppUserProfileImageRequest profileImageRequest)
    {
        var response = await _appUserDto.UpdateProfilePhotoAsync(profileImageRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
}