using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.AdventureCharacter;

public class CreateAdventureCharacterRequest : ICreateRequest
{
    public int AdventureId { get; set; }
    public int CharacterId { get; set; }
}
