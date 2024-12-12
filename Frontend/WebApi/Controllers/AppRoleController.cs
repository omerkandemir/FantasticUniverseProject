using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AppRole;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppRoleController : ControllerBase
{
    private readonly IAppRoleDto _appRoleDto;
    public AppRoleController(IAppRoleDto appRoleDto)
    {
        _appRoleDto = appRoleDto;
    }

    #region Add
    [HttpPost("AddRoleAsync")]
    public async Task<IActionResult> AddRoleAsync([FromBody] CreateAppRoleRequest createRequest)
    {
        var response = await _appRoleDto.AddAsync(createRequest);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }
    #endregion

    #region UpdateRole
    [HttpPut("UpdateRoleAsync")]
    public async Task<IActionResult> UpdateRoleAsync([FromBody] UpdateAppRoleRequest updateRequest)
    {
        try
        {
            var response = await _appRoleDto.UpdateAsync(updateRequest);
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

    #region GetAll
    [HttpGet("GetAllRolesAsync")]
    public async Task<IActionResult> GetAllRolesAsync()
    {
        var response = await _appRoleDto.GetAllAsync();
        return Ok(response.Responses);
    }
    #endregion

    #region Get
    [HttpGet("GetRoleAsync/{id}")]
    public async Task<IActionResult> GetRoleAsync(int id)
    {
        var response = await _appRoleDto.GetAsync(id);
        return Ok(response);
    }
    #endregion
    #region
    [HttpPost("DeleteAsync")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteConfirmationAppRoleRequest deleteConfirmationAppRoleRequest)
    {
        if (deleteConfirmationAppRoleRequest == null || string.IsNullOrEmpty(deleteConfirmationAppRoleRequest.Id.ToString()))
        {
            return BadRequest(new { message = "Geçersiz veri." });
        }

        var response = await _appRoleDto.DeleteAsync(deleteConfirmationAppRoleRequest);
        return Ok(response);
    }
    #endregion

}
