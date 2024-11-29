using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Responses.Concrete.UniverseImage;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniverseImagesController : ControllerBase
    {
        private readonly IUniverseImageDto _universeImageDto;
        public UniverseImagesController(IUniverseImageDto universeImageDto)
        {
            _universeImageDto = universeImageDto;
        }

        #region GetAll
        [Authorize]
        [HttpGet("Listele")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _universeImageDto.GetAllAsync();
            return Ok(response);
        }
        #endregion

        #region GetUserCurrentProfileImage
        [Authorize]
        [HttpGet("GetUserCurrentProfileImage/{id}")]
        public async Task<IActionResult> GetUserCurrentProfileImage(int id)
        {
            var imageResponse = await _universeImageDto.GetAsync(id);
            if (imageResponse is GetUniverseImageResponse successResponse)
            {
                return Ok(new
                {
                    successResponse.Id,
                    successResponse.ImageURL
                });
            }
            return NotFound(new { Message = "Resim bulunamadı." });
        }
        #endregion

        [HttpGet("PrepareUserForRegister")]
        public async Task<IActionResult> PrepareUserForRegister()
        {
            var imageResponse = await _universeImageDto.PrepareUserForRegister();
            if (imageResponse != null && imageResponse.Any())
            {
                return Ok(new
                {
                    Data = imageResponse.ToList()
                });
            }
            return NotFound(new { Message = "Resim bulunamadı." });
        }
    }
}
