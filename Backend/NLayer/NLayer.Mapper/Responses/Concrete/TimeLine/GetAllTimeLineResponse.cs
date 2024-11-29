using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.TimeLine;

public class GetAllTimeLineResponse : IGetAllResponse<IGetTimeLineResponse>
{
    public ICollection<IGetTimeLineResponse>? Responses { get; set; }
}
