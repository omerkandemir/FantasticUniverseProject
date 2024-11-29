using Microsoft.AspNetCore.Identity;
using NLayer.Core.Entities.Abstract;
using System.Security.Claims;

namespace NLayer.Core.Authentication.Abstracts;

public interface IUserService<TUser> where TUser : class, IEntity, new()
{
    Task<IdentityResult> CreateAsync(TUser user, string password);
    Task<TUser> FindByIdAsync(string userId);
    Task<TUser> FindByNameAsync(string userName);
    Task<TUser> FindByEmailAsync(string email);
    Task<bool> CheckPasswordAsync(TUser user, string password);
    Task<IdentityResult> ChangePasswordAsync(TUser user, string currentPassword, string newPassword);
    Task<IdentityResult> UpdateAsync(TUser user);
    Task<TUser> GetUserAsync(ClaimsPrincipal principal);
    Task<ICollection<string>> GetUserRolesAsync(TUser user);
}
