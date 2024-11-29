using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.AdventureCharacter;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.AdventureCharacter;

namespace NLayer.Dto.Managers.Abstract;

public interface IAdventureCharacterDto : IEntityRepositoryAsyncDto<
    IGetAdventureCharacterResponse,
    CreateAdventureCharacterRequest,
    UpdateAdventureCharacterRequest,
    DeleteAdventureCharacterRequest,
    GetAdventureCharacterResponse,
    GetAllAdventureCharacterResponse>
{
}
