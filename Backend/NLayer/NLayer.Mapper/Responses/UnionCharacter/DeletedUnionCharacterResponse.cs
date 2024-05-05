using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.UnionCharacter;

public class DeletedUnionCharacterResponse : IDeletedResponse
{
    public int Id { get; set; }
}
