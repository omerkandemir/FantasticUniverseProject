using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Ability;
using NLayer.Dto.Responses.Ability;

namespace NLayer.Business.Abstracts;

public interface IAbilityService : IEntityServiceRepository<
    CreatedAbilityResponse,CreateAbilityRequest,
    UpdatedAbilityResponse,UpdateAbilityRequest,
    DeletedAbilityResponse,DeleteAbilityRequest,
    GetAllAbilityResponse>
{

}
