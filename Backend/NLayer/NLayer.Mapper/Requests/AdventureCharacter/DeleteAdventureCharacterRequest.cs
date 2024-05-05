using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AdventureCharacter;

public class DeleteAdventureCharacterRequest : IDeleteRequest
{
    public int Id { get; set; }
}
