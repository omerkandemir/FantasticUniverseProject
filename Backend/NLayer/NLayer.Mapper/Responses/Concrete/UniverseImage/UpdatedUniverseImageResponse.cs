using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.UniverseImage;

public class UpdatedUniverseImageResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int UniverseId { get; set; }
    public byte[] ImageURL { get; set; }
}
