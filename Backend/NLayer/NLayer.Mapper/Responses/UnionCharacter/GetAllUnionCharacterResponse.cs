using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.UnionCharacter;

public class GetAllUnionCharacterResponse : IGetResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int UnionId { get; set; }
    public int CharacterId { get; set; }
}
