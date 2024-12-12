using Microsoft.AspNetCore.Identity;
using NLayer.Core.Entities.Abstract;
using System.Security.Claims;

namespace NLayer.Core.Authentication.Concrete.IdentityUser;

public abstract class UserManagerIdentityUser<TUser> where TUser : class, IEntity, new()
{
    private readonly UserManager<TUser> _userManager;
    protected UserManagerIdentityUser(UserManager<TUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<IdentityResult> CreateAsync(TUser user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }
    public async Task<IdentityResult> UpdateAsync(TUser user)
    {
        return await _userManager.UpdateAsync(user);
    }
    public async Task<TUser> FindByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }
    public async Task<TUser> FindByNameAsync(string userName)
    {
        return await _userManager.FindByNameAsync(userName);
    }
    public async Task<TUser> FindByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }
    public async Task<TUser> GetUserAsync(ClaimsPrincipal principal)
    {
        return await _userManager.GetUserAsync(principal);
    }
    public async Task<ICollection<string>> GetUserRolesAsync(TUser user)
    {
        return await _userManager.GetRolesAsync(user);
    }
    public async Task<IdentityResult> AddToRolesAsync(TUser user, ICollection<string> roles)
    {
       return await _userManager.AddToRolesAsync(user, roles);
    }
    public async Task<IdentityResult> RemoveFromRolesAsync(TUser user, ICollection<string> roles)
    {
        return await _userManager.RemoveFromRolesAsync(user, roles);
    }
    public async Task<ICollection<TUser>> RemoveFromRolesAsync(string role)
    {
        return await _userManager.GetUsersInRoleAsync(role);
    }
    public async Task<bool> CheckPasswordAsync(TUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }
    public async Task<IdentityResult> ChangePasswordAsync(TUser user, string currentPassword, string newPassword)
    {
        return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
    }
}
