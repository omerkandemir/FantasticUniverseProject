namespace NLayer.Core.Entities.Authorization;

public class AssignRole
{
    public string Username { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public bool HasAssign { get; set; }
}
