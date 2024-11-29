using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.Galaxy;

public class GetAllGalaxyResponse : IGetAllResponse<IGetGalaxyResponse>
{
    public ICollection<IGetGalaxyResponse>? Responses { get; set; }
}
