using Microsoft.AspNetCore.Identity;
using NLayer.Core.Entities.Abstract;
using System.Security.Claims;

namespace NLayer.Business.Concretes.Authentication.IdentityUser
{
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
        public async Task<bool> CheckPasswordAsync(TUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }
        public async Task<IdentityResult> ChangePasswordAsync(TUser user, string currentPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }
    }
}
