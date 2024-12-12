using Microsoft.AspNetCore.Identity;
using NLayer.Core.Business.Abstract;
using NLayer.Core.Entities.Abstract;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Entities.Authorization;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.Concrete.AppUser;

namespace NLayer.Business.Abstracts;

public interface IAppUserService<TUser, TId> : IEntityServiceRepositoryAsync<TUser,TId> where TUser : class, IEntity<TId>, new()
{
    Task<IReturnType> AddAsyncWithIdentityUser(TUser user, string password);
    Task<IReturnType> UpdateAsyncWithIdentityUser(TUser user);
    Task<IReturnType> UpdateEmailAsyncWithIdentityUser(TUser user, string password);
    Task<IReturnType> ChangePasswordAsyncWithIdentityUser(UpdateAppUserPasswordRequest updateAppUserPasswordRequest);
    Task<IReturnType> ChangeProfileImageAsyncWithIdentityUser(UpdateAppUserProfileImageRequest request);
    Task<IReturnType> ConfirmEmailAsyncWithIdentityUser(ConfirmMailRequest request);
    Task<IDataReturnType<TUser>> GetUserByNameAsyncWithIdentityUser(string userName);
    Task<IDataReturnType<AppUser>> GetUserByIdAsyncWithIdentityUser(string userId);
    Task<IDataReturnType<TUser>> GetUserByMailAsyncWithIdentityUser(string email);
    Task<IDataReturnType<TUser>> GetUserAsyncWithIdentityUser(System.Security.Claims.ClaimsPrincipal claimsPrincipal);
    Task<IDataReturnType<ICollection<string>>> GetUserRolesAsync(string username);
    Task<SignInResult> LoginAsync(LoginRequest loginRequest);
    Task<LoginResponse> LoginProcessAsync(LoginRequest loginRequest);
    Task<LoginResponse> AdminLoginProcessAsync(LoginRequest loginRequest);
    Task<IReturnType> SignOutAsync();
    Task<IReturnType> Register(AppUser user, string password, bool isPersistent);
    Task<IReturnType> AssingRoleAsyncWithIdentityUser(List<AssignRole> assignRole);
}
