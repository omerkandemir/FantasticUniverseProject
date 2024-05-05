using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.UnionCharacter;
using NLayer.Mapper.Responses.UnionCharacter;

namespace NLayer.Dto.Managers.Abstract;

public interface IUnionCharacterDto : IEntityRepositoryDto<
        CreateUnionCharacterRequest,
        UpdateUnionCharacterRequest,
        DeleteUnionCharacterRequest,
        GetAllUnionCharacterResponse>
{
}
