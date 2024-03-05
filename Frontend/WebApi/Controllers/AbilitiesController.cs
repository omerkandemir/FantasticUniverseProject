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
        //[HttpPost]
        //public IActionResult Add(CreateAbilityRequest createdAbilityRequest)
        //{
        //    CreatedAbilityResponse createdAbilityResponse = _abilityService.Add(createdAbilityRequest);
        //    return Ok(createdAbilityResponse);
        //}
        [HttpPost]
        public IActionResult Update(UpdateAbilityRequest updatedAbilityRequest)
        {
            UpdatedAbilityResponse updatedAbilityResponse = _abilityService.Update(updatedAbilityRequest);
            return Ok(updatedAbilityResponse);
        }
        [HttpDelete]
        public IActionResult Delete(DeleteAbilityRequest deleteAbilityRequest)
        {
            DeletedAbilityResponse deletedAbilityResponse = _abilityService.Delete(deleteAbilityRequest);
            return Ok(deletedAbilityResponse);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_abilityService.GetAll());
        }
        //[HttpGet]
        //public IActionResult Get(int Id = 1)
        //{
        //    return Ok(_abilityService.Get(Id));
        //}
        //[HttpPost]
        //public IActionResult Update(UpdateAbilityRequest updateAbilityRequest)
        //{
        //    UpdatedAbilityResponse updatedAbilityResponse = _abilityService.Update(updateAbilityRequest);
        //    return Ok(updatedAbilityResponse);
        //}
    }
}
