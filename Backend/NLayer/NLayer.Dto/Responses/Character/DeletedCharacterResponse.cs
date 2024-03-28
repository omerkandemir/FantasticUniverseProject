using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.Character;

public class DeletedCharacterResponse : IDeletedResponse
{
    public int Id { get; set; }
}
