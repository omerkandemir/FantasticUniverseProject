using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.AdventureCharacter;

public class DeletedAdventureCharacterResponse : IDeletedResponse
{
    public int Id { get; set; }
}
