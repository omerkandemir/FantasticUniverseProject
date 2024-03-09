using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.AdventureCharacter;
using NLayer.Dto.Responses.AdventureCharacter;

namespace NLayer.Business.Abstracts;

public interface IAdventureCharacterService : IEntityServiceRepository<
    CreatedAdventureCharacterResponse, CreateAdventureCharacterRequest,
    UpdatedAdventureCharacterResponse, UpdateAdventureCharacterRequest,
    DeletedAdventureCharacterResponse, DeleteAdventureCharacterRequest,
    GetAllAdventureCharacterResponse>
{
}
