using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.AbilityCharacter;

public class UpdatedAbilityCharacterResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int AbilityId { get; set; }
    public int CharacterId { get; set; }
}
