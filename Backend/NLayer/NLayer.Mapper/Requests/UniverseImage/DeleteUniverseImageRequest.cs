using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.UniverseImage;

public class DeleteUniverseImageRequest : IDeleteRequest
{
    public int Id { get; set; }
}
