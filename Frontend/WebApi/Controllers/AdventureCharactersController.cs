using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Ability;
using NLayer.Dto.Requests.AdventureCharacter;
using NLayer.Dto.Responses.Ability;
using NLayer.Dto.Responses.Adventure;
using NLayer.Dto.Responses.AdventureCharacter;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdventureCharactersController : ControllerBase
    {
        private readonly IAdventureCharacterService _adventureCharacterService;
        public AdventureCharactersController(IAdventureCharacterService adventureCharacterService)
        {
            _adventureCharacterService = adventureCharacterService;
        }
        [HttpPost("Ekle")]
        public IActionResult Add(CreateAdventureCharacterRequest createdAdventureCharacterRequest)
        {
            CreatedAdventureCharacterResponse createdAdventureCharacterResponse = _adventureCharacterService.Add(createdAdventureCharacterRequest);
            return Ok(createdAdventureCharacterResponse);
        }
        [HttpPost("Güncelle")]
        public IActionResult Update(UpdateAdventureCharacterRequest updateAdventureCharacterRequest)
        {
            UpdatedAdventureCharacterResponse updatedAdventureCharacterResponse = _adventureCharacterService.Update(updateAdventureCharacterRequest);
            return Ok(updatedAdventureCharacterResponse);
        }
        [HttpDelete("Sil")]
        public IActionResult Delete(DeleteAdventureCharacterRequest deleteAdventureCharacterRequest)
        {
            DeletedAdventureCharacterResponse deletedAdventureCharacterResponse = _adventureCharacterService.Delete(deleteAdventureCharacterRequest); 
            return Ok(deletedAdventureCharacterResponse);
        }
        [HttpGet("Listele")]
        public IActionResult GetAll()
        {
            return Ok(_adventureCharacterService.GetAll());
        }
        [HttpGet("Getir")]
        public IActionResult Get(int Id = 1)
        {
            return Ok(_adventureCharacterService.Get(Id));
        }
    }
}
