using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.AppRole;

public class GetAllAppRoleResponse : IGetAllResponse<IGetAppRoleResponse>
{
    public ICollection<IGetAppRoleResponse>? Responses { get; set; }
}
