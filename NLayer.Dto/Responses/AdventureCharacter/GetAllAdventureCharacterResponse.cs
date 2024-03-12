using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.AdventureCharacter;

public class GetAllAdventureCharacterResponse : IGetResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int AdventureId { get; set; }
    public int CharacterId { get; set; }
}
