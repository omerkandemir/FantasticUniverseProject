using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.Adventure;

public class GetAllAdventureResponse : IGetAllResponse<IGetAdventureResponse>
{
    public ICollection<IGetAdventureResponse>? Responses { get; set; }
}
