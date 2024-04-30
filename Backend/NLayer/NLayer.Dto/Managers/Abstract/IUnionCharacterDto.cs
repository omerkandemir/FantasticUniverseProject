using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Requests.UnionCharacter;
using NLayer.Dto.Responses.UnionCharacter;

namespace NLayer.Dto.Managers.Abstract;

public interface IUnionCharacterDto : IEntityRepositoryDto<
        CreateUnionCharacterRequest,
        UpdateUnionCharacterRequest,
        DeleteUnionCharacterRequest,
        GetAllUnionCharacterResponse>
{
}
