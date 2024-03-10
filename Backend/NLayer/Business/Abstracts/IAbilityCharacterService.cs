using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.AbilityCharacter;
using NLayer.Dto.Responses.AbilityCharacter;

namespace NLayer.Business.Abstracts;

public interface IAbilityCharacterService : IEntityServiceRepository<
CreatedAbilityCharacterResponse, CreateAbilityCharacterRequest,
UpdatedAbilityCharacterResponse, UpdateAbilityCharacterRequest,
DeletedAbilityCharacterResponse, DeleteAbilityCharacterRequest,
GetAllAbilityCharacterResponse>
{
}
