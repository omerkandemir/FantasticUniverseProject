using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.Union;

public class GetAllUnionResponse : IGetAllResponse<IGetUnionResponse>
{
    public ICollection<IGetUnionResponse>? Responses { get; set; }
}
