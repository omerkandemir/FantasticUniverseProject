using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.AdventureCharacter;

public class DeleteAdventureCharacterRequest : IDeleteRequest
{
    public int Id { get; set; }
}
