using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AbilityCharacter;

public class DeleteAbilityCharacterRequest : IDeleteRequest
{
    public int Id { get; set; }
}
