using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerBusiness.Abstracts;
using NLayerBusiness.Dtos.Requests;
using NLayerBusiness.Dtos.Responses;

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
        [HttpPost]
        public IActionResult Add(CreateAbilityRequest createdAbilityRequest)
        {
            CreatedAbilityResponse createdAbilityResponse = _abilityService.Add(createdAbilityRequest);
            return Ok(createdAbilityResponse);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_abilityService.GetAll());
        }
    }
}
