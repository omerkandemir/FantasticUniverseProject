using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.UnionCharacter;

public class UpdateUnionCharacterRequest : IUpdateRequest
{
    public int Id { get; set; }
    public int UnionId { get; set; }
    public int CharacterId { get; set; }

}
