using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.UnionCharacter;

public class GetUnionCharacterResponse : IGetUnionCharacterResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int UnionId { get; set; }
    public int CharacterId { get; set; }
}
