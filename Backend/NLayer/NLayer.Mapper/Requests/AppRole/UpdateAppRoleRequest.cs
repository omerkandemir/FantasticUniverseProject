using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AppRole;

public class UpdateAppRoleRequest : IUpdateRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
