using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Character;
using NLayer.Dto.Responses.Character;

namespace NLayer.Business.Abstracts;

public interface ICharacterService : IEntityServiceRepository<
    CreatedCharacterResponse, CreateCharacterRequest,
    UpdatedCharacterResponse, UpdateCharacterRequest,
    DeletedCharacterResponse, DeleteCharacterRequest,
    GetAllCharacterResponse>
{
}
