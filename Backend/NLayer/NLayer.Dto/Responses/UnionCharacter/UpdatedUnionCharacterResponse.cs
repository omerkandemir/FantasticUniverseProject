using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.UnionCharacter;

public class UpdatedUnionCharacterResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int UnionId { get; set; }
    public int CharacterId { get; set; }
}
