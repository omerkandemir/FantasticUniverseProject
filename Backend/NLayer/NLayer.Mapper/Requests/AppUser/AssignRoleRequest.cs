using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AppUser;

public class AssignRoleRequest : ICreateRequest
{
    public string Username { get; set; }
    public string RoleName { get; set; }
}
