using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Exceptions;
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

    #region Add
    [HttpGet("Ekle")]
    public async Task<IActionResult> Add([FromBody] CreateAppUserRequest createRequest)
    {
        var response = await _appUserDto.AddAsync(createRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpGet("Register")]
    public async Task<IActionResult> Register([FromBody] CreateAppUserRequest createRequest)
    {
        var response = await _appUserDto.Register(createRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    #endregion

    #region UpdateUser
    [HttpPut("UpdateUser")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateAppUserRequest updateRequest)
    {
        try
        {
            var response = await _appUserDto.UpdateAsync(updateRequest);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }).ToList();
            return BadRequest(new { Message = "Validation hatası oluştu", Errors = errors });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion

    #region Delete
    [HttpDelete("Sil{id}")]
    public async Task<IActionResult> Delete(DeleteAppUserRequest deleteRequest)
    {
        var response = await _appUserDto.DeleteAsync(deleteRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    #endregion

    #region GetAll
    [Authorize]
    [HttpGet("Listele")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _appUserDto.GetAllAsync();
        return Ok(response);
    }
    #endregion

    #region Get
    [HttpGet("Getir{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _appUserDto.GetAsync(id);
        return Ok(response);
    }
    #endregion

    #region GetUserByName
    [HttpGet("GetUserByName/{username}")]
    public async Task<IActionResult> GetUserByName(string username)
    {
        var userResponse = await _appUserDto.GetUserByNameAsync(username);
        if (userResponse.Success)
            return Ok(userResponse);

        return BadRequest(userResponse);
    }
    #endregion

    

    

    #region ConfirmMail
    [HttpPost("ConfirmMail")]
    public async Task<IActionResult> ConfirmMail([FromBody] ConfirmMailRequest confirmMailRequest)
    {
        try
        {
            var response = await _appUserDto.ConfirmMailAsync(confirmMailRequest);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }).ToList();
            return BadRequest(new { Message = "Validation hatası oluştu", Errors = errors });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion

    #region Login
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        try
        {
            var response = await _appUserDto.LoginAsync(loginRequest);

            return Ok(new
            {
                Id = response.Id,
                RedirectTo = response.RedirectTo,
                Email = response.Email,
                IsEmailConfirmed = response.IsEmailConfirmed,
                UserName = response.UserName,
                ImageUrl = response.ImageURL,
                Token = response.Token,
                Message = response.Message,
            });
        }
        catch (UserException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            // Genel bir hata oluşursa
            return StatusCode(500, new { Message = "Sunucuda bir hata oluştu.", Detail = ex.Message });
        }
    }
    #endregion

    #region LogOut
    [Authorize]
    [HttpPost("Logout")]
    public async Task<IActionResult> Logout()
    {
        try
        {
            var response = await _appUserDto.SignOutAsync();
            //HttpContext.SignOutAsync(); // Kullanıcı oturumunu kapat
            return response.Success ? Ok(new { Message = response.Message }) : BadRequest(new { Message = response.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Çıkış işlemi sırasında bir hata oluştu.", Error = ex.Message });
        }
    }
    #endregion

    #region ChangePassword
    [HttpPut("UpdatePassword")]
    public async Task<IActionResult> ChangePassword([FromBody] UpdateAppUserPasswordRequest updatePasswordRequest)
    {
        try
        {
            var response = await _appUserDto.UpdatePasswordAsync(updatePasswordRequest);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }).ToList();
            return BadRequest(new { Message = "Validation hatası oluştu", Errors = errors });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion


    #region UpdateProfileImage
    [HttpPut("UpdateProfileImage")]
    public async Task<IActionResult> UpdateProfileImage([FromBody] UpdateAppUserProfileImageRequest profileImageRequest)
    {
        try
        {
            var response = await _appUserDto.UpdateProfilePhotoAsync(profileImageRequest);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }).ToList();
            return BadRequest(new { Message = "Validation hatası oluştu", Errors = errors });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion

    #region UpdateUserEmail
    [HttpPut("UpdateUserEmail")]
    public async Task<IActionResult> UpdateUserEmail([FromBody] UpdateAppUserEmailRequest updateAppUserEmailRequest)
    {
        try
        {
            var response = await _appUserDto.UpdateEmailAsync(updateAppUserEmailRequest);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }).ToList();
            return BadRequest(new { Message = "Validation hatası oluştu", Errors = errors });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
}