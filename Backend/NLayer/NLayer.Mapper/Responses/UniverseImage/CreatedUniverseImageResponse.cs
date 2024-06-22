using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.UniverseImage;

public class CreatedUniverseImageResponse : ICreatedResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int UniverseId { get; set; }
    public byte[] ImageURL { get; set; }
}
