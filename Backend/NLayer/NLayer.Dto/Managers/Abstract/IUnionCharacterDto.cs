using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.UnionCharacter;
using NLayer.Mapper.Responses.UnionCharacter;

namespace NLayer.Dto.Managers.Abstract;

public interface IUnionCharacterDto : IEntityRepositoryAsyncDto<
        CreateUnionCharacterRequest,
        UpdateUnionCharacterRequest,
        DeleteUnionCharacterRequest,
        GetAllUnionCharacterResponse>
{
}
