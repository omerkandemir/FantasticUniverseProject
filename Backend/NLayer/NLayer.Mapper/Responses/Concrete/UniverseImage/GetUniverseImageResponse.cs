using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.UniverseImage;

public class GetUniverseImageResponse : IGetUniverseImageResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int UniverseId { get; set; }
    public byte[] ImageURL { get; set; }
}
