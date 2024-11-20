using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.AbilityCharacter;

public class GetAbilityCharacterResponse : IGetAbilityCharacterResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int AbilityId { get; set; }
    public int CharacterId { get; set; }
}
