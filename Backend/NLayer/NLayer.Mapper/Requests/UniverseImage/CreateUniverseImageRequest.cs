using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.UniverseImage;

public class CreateUniverseImageRequest : ICreateRequest
{
    public int UniverseId { get; set; }
    public byte[] ImageURL { get; set; }
}
