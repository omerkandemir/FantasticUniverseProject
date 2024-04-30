using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Requests.AdventureCharacter;
using NLayer.Dto.Responses.AdventureCharacter;

namespace NLayer.Dto.Managers.Abstract;

public interface IAdventureCharacterDto : IEntityRepositoryDto<
    CreateAdventureCharacterRequest,
    UpdateAdventureCharacterRequest,
    DeleteAdventureCharacterRequest,
    GetAllAdventureCharacterResponse>
{
}
