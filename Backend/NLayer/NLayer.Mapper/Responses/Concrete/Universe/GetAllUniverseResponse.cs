using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.Universe;

public class GetAllUniverseResponse : IGetAllResponse<IGetUniverseResponse>
{
    public ICollection<IGetUniverseResponse>? Responses { get; set; }
}