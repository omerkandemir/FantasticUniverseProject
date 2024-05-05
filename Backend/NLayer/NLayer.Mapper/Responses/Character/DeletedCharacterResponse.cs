using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Character;

public class DeletedCharacterResponse : IDeletedResponse
{
    public int Id { get; set; }
}
