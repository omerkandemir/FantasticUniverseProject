using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Authentication;
using NLayer.Dto.Managers.Abstract;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserImagesController : ControllerBase
    {
        private readonly IUserImageDto _userImageDto;
        private readonly IAppUserDto _appUserDto;
        public UserImagesController(IUserImageDto userImageDto, IAppUserDto appUserDto)
        {
            _userImageDto = userImageDto;
            _appUserDto = appUserDto;
        }

        #region GetAll
        [Authorize]
        [HttpGet("Listele")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userImageDto.GetAllAsync();
            return Ok(response);
        }
        #endregion

        #region GetAllUsersProfileImages
        [Authorize]
        [HttpGet("GetAllUsersProfileImages/{username}")]
        public async Task<IActionResult> GetAllUsersProfileImages(string username)
        {
            var userResponse = await _appUserDto.GetUserByNameAsync(username);
            if (!userResponse.Success)
            {
                return BadRequest(userResponse);
            }

            var user = (userResponse as SuccessResponse<AppUser>).Entity;
            var allImages = await _userImageDto.GetUsersImage();

            return Ok(new
            {
                SelectedImageId = user.UniverseImageId,
                GetAllUniverseImageResponses = allImages.Responses.Select(image => new
                {
                    image.Id,
                    image.ImageURL,  
                    image.UniverseId
                }).ToList()  
            });
        }
        #endregion
    }
}
