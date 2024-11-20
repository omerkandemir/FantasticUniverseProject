using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.UnionCharacter;

public class UpdatedUnionCharacterResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int UnionId { get; set; }
    public int CharacterId { get; set; }
}
