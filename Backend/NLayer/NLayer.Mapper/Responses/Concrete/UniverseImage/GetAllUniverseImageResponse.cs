using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.UniverseImage;

public class GetAllUniverseImageResponse : IGetAllResponse<IGetUniverseImageResponse>
{
    public ICollection<IGetUniverseImageResponse>? Responses { get; set; }
}
