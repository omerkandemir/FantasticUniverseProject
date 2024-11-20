using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.AdventureCharacter;

public class DeletedAdventureCharacterResponse : IDeletedResponse
{
    public int Id { get; set; }
}
