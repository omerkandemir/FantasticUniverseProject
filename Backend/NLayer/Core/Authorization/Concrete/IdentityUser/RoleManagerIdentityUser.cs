using Microsoft.AspNetCore.Identity;
using NLayer.Core.Entities.Abstract;

namespace NLayer.Core.Authorization.Concrete.IdentityUser;

public abstract class RoleManagerIdentityUser<TRole> where TRole : class, IEntity, new()
{
    private readonly RoleManager<TRole> _roleManager;
    protected RoleManagerIdentityUser(RoleManager<TRole> roleManager)
    {
        _roleManager = roleManager;
    }
    public async Task<IdentityResult> CreateRoleAsync(TRole role) => await _roleManager.CreateAsync(role);
    public async Task<IdentityResult> UpdateRoleAsync(TRole role) => await _roleManager.UpdateAsync(role);
    public async Task<IdentityResult> DeleteRoleAsync(TRole role) => await _roleManager.DeleteAsync(role);
    public async Task<TRole> FindRoleByNameAsync(string roleName) => await _roleManager.FindByNameAsync(roleName);
    public async Task<TRole> FindRoleById(int Id) => await _roleManager.FindByIdAsync(Id.ToString());
    public ICollection<TRole> GetAllRoles() => _roleManager.Roles.ToList();
}
