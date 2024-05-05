using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Character;
using NLayer.Mapper.Responses.Character;

namespace NLayer.Dto.Managers.Abstract;

public interface ICharacterDto : IEntityRepositoryDto<
        CreateCharacterRequest,
        UpdateCharacterRequest,
        DeleteCharacterRequest,
        GetAllCharacterResponse>
{
}
