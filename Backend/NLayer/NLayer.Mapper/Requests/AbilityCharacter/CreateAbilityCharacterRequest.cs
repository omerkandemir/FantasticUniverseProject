using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AbilityCharacter;

public class CreateAbilityCharacterRequest : ICreateRequest
{
    public int AbilityId { get; set; }
    public int CharacterId { get; set; }
}
