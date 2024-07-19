using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.UniverseImage;

public class UpdateUniverseImageRequest : IUpdateRequest
{
    public int Id { get; set; }
    public int UniverseId { get; set; }
    public byte[] ImageURL { get; set; }
}
