using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Requests.Ability;
using NLayer.Dto.Responses.Ability;

namespace NLayer.Dto.Managers.Abstract;

public interface IAbilityDto : IEntityRepositoryDto<
    CreateAbilityRequest,
    UpdateAbilityRequest,
    DeleteAbilityRequest,
    GetAllAbilityResponse>
{
}
