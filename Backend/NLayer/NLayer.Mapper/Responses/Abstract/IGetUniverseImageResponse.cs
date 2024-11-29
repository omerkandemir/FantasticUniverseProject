using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Abstract;

public interface IGetUniverseImageResponse : IGetResponse
{
    public int UniverseId { get; set; }
    public byte[] ImageURL { get; set; }
}
