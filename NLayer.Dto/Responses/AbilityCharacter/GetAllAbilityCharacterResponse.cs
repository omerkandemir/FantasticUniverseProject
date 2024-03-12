using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.AbilityCharacter;

public class GetAllAbilityCharacterResponse : IGetResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int AbilityId { get; set; }
    public int CharacterId { get; set; }
}
