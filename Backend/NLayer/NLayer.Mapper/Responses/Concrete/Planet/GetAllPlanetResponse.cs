using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.Planet;

public class GetAllPlanetResponse : IGetAllResponse<IGetPlanetResponse>
{
    public ICollection<IGetPlanetResponse>? Responses { get; set; }
}

