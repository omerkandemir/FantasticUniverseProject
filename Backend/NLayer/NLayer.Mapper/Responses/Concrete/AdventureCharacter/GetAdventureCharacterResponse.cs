using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.AdventureCharacter;

public class GetAdventureCharacterResponse : IGetAdventureCharacterResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int AdventureId { get; set; }
    public int CharacterId { get; set; }
}
