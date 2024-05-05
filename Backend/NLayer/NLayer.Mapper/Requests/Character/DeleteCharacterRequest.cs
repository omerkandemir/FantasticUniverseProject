using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Character;

public class DeleteCharacterRequest : IDeleteRequest
{
    public int Id { get; set; }
}
