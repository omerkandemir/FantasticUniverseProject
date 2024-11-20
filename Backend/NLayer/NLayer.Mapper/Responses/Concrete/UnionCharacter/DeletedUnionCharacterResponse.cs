using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.UnionCharacter;

public class DeletedUnionCharacterResponse : IDeletedResponse
{
    public int Id { get; set; }
}
