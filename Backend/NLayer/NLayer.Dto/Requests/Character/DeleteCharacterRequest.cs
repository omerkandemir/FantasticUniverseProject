using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.Character;

public class DeleteCharacterRequest : IDeleteRequest
{
    public int Id { get; set; }
}
