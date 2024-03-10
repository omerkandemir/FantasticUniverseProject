using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.AbilityCharacter;
using NLayer.Dto.Responses.AbilityCharacter;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbilityCharactersController : ControllerBase
    {
        IAbilityCharacterService _abilityCharacterService;
        public AbilityCharactersController(IAbilityCharacterService abilityCharacterService)
        {
            _abilityCharacterService = abilityCharacterService;
        }
        [HttpPost("Ekle")]
        public IActionResult Add(CreateAbilityCharacterRequest createdRequest)
        {
            CreatedAbilityCharacterResponse createdResponse = _abilityCharacterService.Add(createdRequest);
            return Ok(createdResponse);
        }

        [HttpPost("Güncelle")]
        public IActionResult Update(UpdateAbilityCharacterRequest updatedRequest)
        {
            UpdatedAbilityCharacterResponse updatedResponse = _abilityCharacterService.Update(updatedRequest);
            return Ok(updatedResponse);
        }
        [HttpDelete("Sil")]
        public IActionResult Delete(DeleteAbilityCharacterRequest deleteRequest)
        {
            DeletedAbilityCharacterResponse deletedResponse = _abilityCharacterService.Delete(deleteRequest);
            return Ok(deletedResponse);
        }

        [HttpGet("Listele")]
        public IActionResult GetAll()
        {
            return Ok(_abilityCharacterService.GetAll());
        }
        [HttpGet("Getir")]
        public IActionResult Get(int Id = 1)
        {
            return Ok(_abilityCharacterService.Get(Id));
        }
    }
}
