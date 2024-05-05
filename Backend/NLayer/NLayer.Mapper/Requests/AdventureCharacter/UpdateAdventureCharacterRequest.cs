using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AdventureCharacter;

public class UpdateAdventureCharacterRequest : IUpdateRequest
{
    public int Id { get; set; }
    public int AdventureId { get; set; }
    public int CharacterId { get; set; }
}
