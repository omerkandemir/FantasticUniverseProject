using NLayerBusiness.Dtos.Requests;
using NLayerBusiness.Dtos.Responses;
using NLayerEntities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerBusiness.Abstracts
{
    public interface IAbilityService
    {
        CreatedAbilityResponse Add(CreateAbilityRequest ability);
        UpdatedAbilityResponse Update(UpdateAbilityRequest ability);
        List<GetAllAbilityResponse> GetAll();
        GetAllAbilityResponse Get(int id);
    }
}
