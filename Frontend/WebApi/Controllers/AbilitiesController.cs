using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Requests.Ability;
using NLayer.Dto.Responses.Ability;
using NLayer.Business.Abstracts;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbilitiesController : ControllerBase
    {
        private readonly IAbilityService _abilityService;
        public AbilitiesController(IAbilityService abilityService)
        {
            _abilityService = abilityService;
        }
        [HttpPost("Ekle")]
        public IActionResult Add(CreateAbilityRequest createdAbilityRequest)
        {
            CreatedAbilityResponse createdAbilityResponse = _abilityService.Add(createdAbilityRequest);
            return Ok(createdAbilityResponse);
        }
        [HttpPost("Güncelle")]
        public IActionResult Update(UpdateAbilityRequest updatedAbilityRequest)
        {
            UpdatedAbilityResponse updatedAbilityResponse = _abilityService.Update(updatedAbilityRequest);
            return Ok(updatedAbilityResponse);
        }
        [HttpDelete("Sil")]
        public IActionResult Delete(DeleteAbilityRequest deleteAbilityRequest)
        {
            DeletedAbilityResponse deletedAbilityResponse = _abilityService.Delete(deleteAbilityRequest);
            return Ok(deletedAbilityResponse);
        }

        [HttpGet("Listele")]
        public IActionResult GetAll()
        {
            return Ok(_abilityService.GetAll());
        }
        [HttpGet("Getir")]
        public IActionResult Get(int Id = 1)
        {
            return Ok(_abilityService.Get(Id));
        }

    }
}
