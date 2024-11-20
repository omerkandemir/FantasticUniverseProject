using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.Ability;

public class GetAllAbilityResponse : IGetAllResponse<IGetAbilityResponse>
{
    public ICollection<IGetAbilityResponse>? Responses { get; set; }
}
