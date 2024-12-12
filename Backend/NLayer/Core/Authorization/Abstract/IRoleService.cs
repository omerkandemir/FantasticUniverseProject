using Microsoft.AspNetCore.Identity;
using NLayer.Core.Entities.Abstract;
using NLayer.Core.Entities.Authorization;

namespace NLayer.Core.Authorization.Abstract;

public interface IRoleService<TRole> where TRole : class, IEntity, new()
{
    Task<IdentityResult> CreateRoleAsync(TRole role);
    Task<IdentityResult> UpdateRoleAsync(TRole role);
    Task<IdentityResult> DeleteRoleAsync(TRole role);
    Task<TRole> FindRoleByNameAsync(string roleName);
    Task<TRole> FindRoleById(int Id);
    ICollection<TRole> GetAllRoles();
}

