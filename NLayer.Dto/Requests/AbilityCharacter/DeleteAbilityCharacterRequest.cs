using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.AbilityCharacter;

public class DeleteAbilityCharacterRequest : IDeleteRequest
{
    public int Id { get; set; }
}
