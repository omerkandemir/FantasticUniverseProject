using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.UnionCharacter;

public class DeleteUnionCharacterRequest : IDeleteRequest
{
    public int Id { get; set; }
}
