using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.AbilityCharacter;
using NLayer.Dto.Responses.AbilityCharacter;
using NLayer.Entities.Concretes;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbilityCharactersController : ControllerBase
    {
        private readonly IAbilityCharacterService _abilityCharacterService;
        private readonly IMapper _mapper;
        public AbilityCharactersController(IAbilityCharacterService abilityCharacterService, IMapper mapper)
        {
            _abilityCharacterService = abilityCharacterService;
            _mapper = mapper;
        }
        [HttpPost("Ekle")]
        public IActionResult Add(CreateAbilityCharacterRequest createRequest)
        {
            var value = _mapper.Map<AbilityCharacter>(createRequest);
            _abilityCharacterService.Add(value);
            var response = _mapper.Map<CreatedAbilityCharacterResponse>(value);
            return Ok(response);
        }

        [HttpPost("Güncelle")]
        public IActionResult Update(UpdateAbilityCharacterRequest updateRequest)
        {
            var value = _mapper.Map<AbilityCharacter>(updateRequest);
            _abilityCharacterService.Update(value);
            var response = _mapper.Map<UpdatedAbilityCharacterResponse>(value);
            return Ok(response);
        }
        [HttpDelete("Sil")]
        public IActionResult Delete(DeleteAbilityCharacterRequest deleteRequest)
        {
            var value = _mapper.Map<AbilityCharacter>(deleteRequest);
            _abilityCharacterService.Delete(value);
            var response = _mapper.Map<DeletedAbilityCharacterResponse>(value);
            return Ok(response);
        }

        [HttpGet("Listele")]
        public IActionResult GetAll()
        {
            var value = _abilityCharacterService.GetAll();
            var response = _mapper.Map<List<GetAllAbilityCharacterResponse>>(value.Data);
            return Ok(response);
        }
        [HttpGet("Getir")]
        public IActionResult Get(int Id = 1)
        {
            var value = _abilityCharacterService.Get(Id);
            var response = _mapper.Map<GetAllAbilityCharacterResponse>(value.Data);
            return Ok(response);
        }
    }
}
