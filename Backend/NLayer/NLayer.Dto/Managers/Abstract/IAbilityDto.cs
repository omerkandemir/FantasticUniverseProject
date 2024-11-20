using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Ability;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Ability;

namespace NLayer.Dto.Managers.Abstract;

public interface IAbilityDto : IEntityRepositoryAsyncDto<
    IGetAbilityResponse,
    CreateAbilityRequest,
    UpdateAbilityRequest,
    DeleteAbilityRequest,
    GetAbilityResponse,
    GetAllAbilityResponse>
{
}
