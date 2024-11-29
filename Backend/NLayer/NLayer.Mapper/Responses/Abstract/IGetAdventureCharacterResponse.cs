using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Abstract;

public interface IGetAdventureCharacterResponse : IGetResponse
{
    public int AdventureId { get; set; }
    public int CharacterId { get; set; }
}
