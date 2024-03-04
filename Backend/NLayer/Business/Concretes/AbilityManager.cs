using NLayerBusiness.Abstracts;
using NLayerBusiness.Concretes.ValidationRules.FluentValidation;
using NLayerBusiness.Dtos.Requests;
using NLayerBusiness.Dtos.Responses;
using NLayerCore.Business.Utilities;
using NLayerDataAccess.Abstracts;
using NLayerEntities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerBusiness.Concretes
{
    public class AbilityManager : IAbilityService
    {
        private readonly IAbilityDal _abilityDal;
        public AbilityManager(IAbilityDal abilityDal)
        {
            _abilityDal = abilityDal;
        }

        public CreatedAbilityResponse Add(CreateAbilityRequest createAbilityRequest)
        {
            // business Rules
            //İstekten gelen bilgileri nesneye ekle daha sonra da response u döndür

            //Mapping -->automapper
            Ability ability = new();
            ability.Name = createAbilityRequest.Name;
            ability.CreatedDate = DateTime.Now;


            _abilityDal.Add(ability);

            CreatedAbilityResponse createAbilityResponse = new CreatedAbilityResponse();
            createAbilityResponse.Name = ability.Name;
            createAbilityResponse.Id = 4;
            createAbilityResponse.CreatedDate = ability.CreatedDate;

            return createAbilityResponse;
        }

        public List<GetAllAbilityResponse> GetAll()
        {
            List<Ability> abilities = _abilityDal.GetAll();

            List<GetAllAbilityResponse> getAllAbilityResponses = new List<GetAllAbilityResponse>();

            foreach (var ability in abilities)
            {
                GetAllAbilityResponse getAllAbilityResponse = new GetAllAbilityResponse();
                getAllAbilityResponse.Id = ability.Id;
                getAllAbilityResponse.Name = ability.Name;
                getAllAbilityResponse.CreatedDate = ability.CreatedDate;

                getAllAbilityResponses.Add(getAllAbilityResponse);
            }

            return getAllAbilityResponses;
        }

        //public void Add(Ability ability)
        //{
        //    ValidationTool.Validate(new AbilityValidator(), ability);
        //    _abilityDal.Add(ability);
        //}

        //public List<Ability> GetAll()
        //{
        //    return _abilityDal.GetAll();
        //}
    }
}
