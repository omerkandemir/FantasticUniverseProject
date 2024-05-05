using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AbilityCharacter;

public class UpdateAbilityCharacterRequest : IUpdateRequest
{
    public int Id { get; set; }
    public int AbilityId { get; set; }
    public int CharacterId { get; set; }
}
