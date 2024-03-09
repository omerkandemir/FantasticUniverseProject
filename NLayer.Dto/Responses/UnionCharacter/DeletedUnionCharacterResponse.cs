using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.UnionCharacter;

public class DeletedUnionCharacterResponse : IDeletedResponse
{
    public int Id { get; set; }
}
