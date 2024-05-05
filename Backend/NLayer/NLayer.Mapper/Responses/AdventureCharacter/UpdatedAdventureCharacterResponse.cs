using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.AdventureCharacter;

public class UpdatedAdventureCharacterResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int AdventureId { get; set; }
    public int CharacterId { get; set; }
}
