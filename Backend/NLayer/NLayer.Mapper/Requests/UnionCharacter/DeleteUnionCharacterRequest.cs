using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.UnionCharacter;

public class DeleteUnionCharacterRequest : IDeleteRequest
{
    public int Id { get; set; }
}
