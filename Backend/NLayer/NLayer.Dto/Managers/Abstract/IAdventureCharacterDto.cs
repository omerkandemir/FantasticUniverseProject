using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.AdventureCharacter;
using NLayer.Mapper.Responses.AdventureCharacter;

namespace NLayer.Dto.Managers.Abstract;

public interface IAdventureCharacterDto : IEntityRepositoryDto<
    CreateAdventureCharacterRequest,
    UpdateAdventureCharacterRequest,
    DeleteAdventureCharacterRequest,
    GetAllAdventureCharacterResponse>
{
}
