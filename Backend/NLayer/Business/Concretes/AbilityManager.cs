using NLayer.Dto.Requests.Ability;
using NLayer.Dto.Responses.Ability;
using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.ValidationRules.FluentValidation;
using NLayer.Core.Business.Utilities;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Concretes
{
    public class AbilityManager : IAbilityService
    {
        private readonly IAbilityDal _abilityDal;
        public AbilityManager(IAbilityDal abilityDal)
        {
            _abilityDal = abilityDal;
        }
        public UpdatedAbilityResponse Update(UpdateAbilityRequest updateAbilityRequest)
        {
            Ability ability = new();
            ability.Id = updateAbilityRequest.Id;
            ability.Name = updateAbilityRequest.Name;

            _abilityDal.Update(ability);

            UpdatedAbilityResponse updatedAbilityResponse = new UpdatedAbilityResponse();
            updatedAbilityResponse.Id = ability.Id;
            updatedAbilityResponse.Name = ability.Name;
            updatedAbilityResponse.UpdatedDate = (DateTime)ability.UpdatedDate;
            return updatedAbilityResponse;
        }
        public DeletedAbilityResponse Delete(DeleteAbilityRequest deleteAbilityRequest)
        {
            Ability ability = new() { Id = deleteAbilityRequest.Id };
            _abilityDal.Delete(ability);
            DeletedAbilityResponse deletedAbilityResponse = new DeletedAbilityResponse();
            deleteAbilityRequest.Id = ability.Id;
            return deletedAbilityResponse;
        }
        public CreatedAbilityResponse Add(CreateAbilityRequest createAbilityRequest)
        {
            // business Rules
            //İstekten gelen bilgileri nesneye ekle daha sonra da response u döndür

            //Mapping -->automapper
            Ability ability = new();
            ability.Name = createAbilityRequest.Name;
            //ability.CreatedDate = DateTime.Now;

            ValidationTool.Validate(new AbilityValidator(), ability);
            _abilityDal.Add(ability);

            CreatedAbilityResponse createAbilityResponse = new CreatedAbilityResponse();
            createAbilityResponse.Id = ability.Id;
            createAbilityResponse.Name = ability.Name;
            createAbilityResponse.CreatedDate = ability.CreatedDate;
            createAbilityResponse.IsActive = ability.IsActive;

            return createAbilityResponse;
        }

        public GetAllAbilityResponse Get(int id)
        {
            GetAllAbilityResponse getAllAbilityResponse = new GetAllAbilityResponse();
            Ability ability = _abilityDal.Get(x => x.Id == id);
            getAllAbilityResponse.Id = ability.Id;
            getAllAbilityResponse.Name = ability.Name;
            getAllAbilityResponse.CreatedDate = ability.CreatedDate;
            return getAllAbilityResponse;
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
    }
}
