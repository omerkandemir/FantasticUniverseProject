using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.UniverseImage;
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
            return Ok(imageResponse);
        }

        [HttpGet("GetDefaultImagesAsync")]
        public async Task<IActionResult> GetDefaultImagesAsync()
        {
            var imageResponse = await _universeImageDto.PrepareUserForRegister();
            return Ok(imageResponse);
        }
        [HttpPost("AddDefaultImagesAsync")]
        public async Task<IActionResult> AddDefaultImagesAsync([FromBody] List<CreateUniverseImageRequest> createRequest)
        {
            try
            {
                var response = await _universeImageDto.AddRangeAsync(createRequest);
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

        [HttpPost("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteUniverseImageRequest deleteUniverseImageRequest)
        {
            var response = await _universeImageDto.DeleteAsync(deleteUniverseImageRequest);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
