using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.Star;

public class GetAllStarResponse : IGetAllResponse<IGetStarResponse>
{
    public ICollection<IGetStarResponse>? Responses { get; set; }
}
