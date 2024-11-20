using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.Species;

public class GetAllSpeciesResponse : IGetAllResponse<IGetSpeciesResponse>
{
    public ICollection<IGetSpeciesResponse>? Responses { get; set; }
}
