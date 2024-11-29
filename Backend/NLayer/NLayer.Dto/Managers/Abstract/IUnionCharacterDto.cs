using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.UnionCharacter;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.UnionCharacter;

namespace NLayer.Dto.Managers.Abstract;

public interface IUnionCharacterDto : IEntityRepositoryAsyncDto<
        IGetUnionCharacterResponse,
        CreateUnionCharacterRequest,
        UpdateUnionCharacterRequest,
        DeleteUnionCharacterRequest,
        GetUnionCharacterResponse,
        GetAllUnionCharacterResponse>
{
}
