using Microsoft.AspNetCore.Identity;
using NLayer.Core.Business.Abstract;
using NLayer.Core.Entities.Abstract;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.Concrete.AppUser;

namespace NLayer.Business.Abstracts;

public interface IAppUserService<TUser> : IEntityServiceRepositoryAsync<TUser> where TUser : class, IEntity, new()
{
    Task<IReturnType> AddAsyncWithIdentityUser(TUser user, string password);
    Task<IReturnType> UpdateAsyncWithIdentityUser(TUser user);
    Task<IReturnType> UpdateEmailAsyncWithIdentityUser(TUser user, string password);
    Task<IReturnType> ChangePasswordAsyncWithIdentityUser(UpdateAppUserPasswordRequest updateAppUserPasswordRequest);
    Task<IReturnType> ChangeProfileImageAsyncWithIdentityUser(UpdateAppUserProfileImageRequest request);
    Task<IReturnType> ConfirmEmailAsyncWithIdentityUser(ConfirmMailRequest request);
    Task<IDataReturnType<TUser>> GetUserByNameAsyncWithIdentityUser(string userName);
    Task<IDataReturnType<TUser>> GetUserByMailAsyncWithIdentityUser(string email);
    Task<IDataReturnType<TUser>> GetUserAsyncWithIdentityUser(System.Security.Claims.ClaimsPrincipal claimsPrincipal);
    Task<IDataReturnType<ICollection<string>>> GetUserRolesAsync(TUser user);
    Task<SignInResult> LoginAsync(LoginRequest loginRequest);
    Task<LoginResponse> LoginProcessAsync(LoginRequest loginRequest);
    Task<IReturnType> SignOutAsync();
    Task<IReturnType> Register(AppUser user, string password, bool isPersistent);
}
