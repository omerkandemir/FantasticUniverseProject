using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Requests.Character;
using NLayer.Dto.Responses.Character;

namespace NLayer.Dto.Managers.Abstract;

public interface ICharacterDto : IEntityRepositoryDto<
        CreateCharacterRequest,
        UpdateCharacterRequest,
        DeleteCharacterRequest,
        GetAllCharacterResponse>
{
}
