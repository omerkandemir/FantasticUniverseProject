using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.AbilityCharacter;
using NLayer.Mapper.Responses.AbilityCharacter;

namespace NLayer.Dto.Managers.Abstract;

public interface IAbilityCharacterDto : IEntityRepositoryDto<
    CreateAbilityCharacterRequest, 
    UpdateAbilityCharacterRequest, 
    DeleteAbilityCharacterRequest,
    GetAllAbilityCharacterResponse>
{
}
