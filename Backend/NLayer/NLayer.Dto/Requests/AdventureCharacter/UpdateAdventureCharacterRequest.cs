using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.AdventureCharacter;

public class UpdateAdventureCharacterRequest : IUpdateRequest
{
    public int Id { get; set; }
    public int AdventureId { get; set; }
    public int CharacterId { get; set; }
}
