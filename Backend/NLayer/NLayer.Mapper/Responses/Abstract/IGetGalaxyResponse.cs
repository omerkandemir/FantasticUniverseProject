using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Abstract;

public interface IGetGalaxyResponse : IGetResponse
{
    public int UniverseId { get; set; }
    public string Name { get; set; }
}
