using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AppRole;

public class CreateAppRoleRequest : ICreateRequest
{
    public string Name { get; set; }
}
