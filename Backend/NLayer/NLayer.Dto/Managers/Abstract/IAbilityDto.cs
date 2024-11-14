using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Ability;
using NLayer.Mapper.Responses.Ability;

namespace NLayer.Dto.Managers.Abstract;

public interface IAbilityDto : IEntityRepositoryAsyncDto<
    CreateAbilityRequest,
    UpdateAbilityRequest,
    DeleteAbilityRequest,
    GetAllAbilityResponse>
{
}
