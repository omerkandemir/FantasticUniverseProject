using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Character;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Character;

namespace NLayer.Dto.Managers.Abstract;

public interface ICharacterDto : IEntityRepositoryAsyncDto<
        IGetCharacterResponse,
        CreateCharacterRequest,
        UpdateCharacterRequest,
        DeleteCharacterRequest,
        GetCharacterResponse,
        GetAllCharacterResponse>
{
}
