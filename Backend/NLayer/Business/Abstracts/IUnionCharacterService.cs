using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.UnionCharacter;
using NLayer.Dto.Responses.UnionCharacter;

namespace NLayer.Business.Abstracts;

public interface IUnionCharacterService : IEntityServiceRepository<
    CreatedUnionCharacterResponse, CreateUnionCharacterRequest,
    UpdatedUnionCharacterResponse, UpdateUnionCharacterRequest,
    DeletedUnionCharacterResponse, DeleteUnionCharacterRequest,
    GetAllUnionCharacterResponse>
{
}
