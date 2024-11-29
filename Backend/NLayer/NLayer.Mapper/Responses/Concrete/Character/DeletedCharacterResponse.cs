using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.Character;

public class DeletedCharacterResponse : IDeletedResponse
{
    public int Id { get; set; }
}
