using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Abstract;

public interface IGetTimeLineResponse : IGetResponse
{
    public int UniverseId { get; set; }
    public int StartingAdventureId { get; set; }
}
