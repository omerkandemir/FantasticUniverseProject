using NLayer.Dto.Requests.Ability;
using NLayer.Dto.Responses.Ability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Abstracts
{
    public interface IAbilityService
    {
        CreatedAbilityResponse Add(CreateAbilityRequest ability);
        UpdatedAbilityResponse Update(UpdateAbilityRequest ability);
        DeletedAbilityResponse Delete(DeleteAbilityRequest Ability);
        List<GetAllAbilityResponse> GetAll();
        GetAllAbilityResponse Get(int id);
    }
}
