using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.AppUser;

public class AssignRoleResponse : ICreatedResponse
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string RoleName { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
}
