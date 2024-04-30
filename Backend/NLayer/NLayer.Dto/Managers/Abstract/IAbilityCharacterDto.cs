using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Requests.AbilityCharacter;
using NLayer.Dto.Responses.AbilityCharacter;

namespace NLayer.Dto.Managers.Abstract;

public interface IAbilityCharacterDto : IEntityRepositoryDto<
    CreateAbilityCharacterRequest, 
    UpdateAbilityCharacterRequest, 
    DeleteAbilityCharacterRequest,
    GetAllAbilityCharacterResponse>
{
}
