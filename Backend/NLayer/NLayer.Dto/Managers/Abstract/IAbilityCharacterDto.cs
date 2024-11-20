using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.AbilityCharacter;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.AbilityCharacter;

namespace NLayer.Dto.Managers.Abstract;

public interface IAbilityCharacterDto : IEntityRepositoryAsyncDto<
    IGetAbilityCharacterResponse, 
    CreateAbilityCharacterRequest,
    UpdateAbilityCharacterRequest, 
    DeleteAbilityCharacterRequest,
    GetAbilityCharacterResponse, 
    GetAllAbilityCharacterResponse>
{
}
