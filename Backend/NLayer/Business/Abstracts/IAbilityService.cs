using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Ability;
using NLayer.Dto.Responses.Ability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Abstracts
{
    public interface IAbilityService : IEntityServiceRepository<
        CreatedAbilityResponse,CreateAbilityRequest,
        UpdatedAbilityResponse,UpdateAbilityRequest,
        DeletedAbilityResponse,DeleteAbilityRequest,
        GetAllAbilityResponse>
    {

    }
}
