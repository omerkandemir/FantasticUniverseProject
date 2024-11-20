using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.AppUser;

public class GetAllAppUserResponse : IGetAllResponse<IGetAppUserResponse>
{
    public ICollection<IGetAppUserResponse>? Responses { get; set; }
}
