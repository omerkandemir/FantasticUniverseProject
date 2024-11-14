using NLayer.Core.Business.Abstract;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.Mapper.Requests.AppUser;

namespace NLayer.Business.Abstracts;

public interface IAppUserService : IEntityServiceRepositoryAsync<AppUser>
{
    Task<IReturnType> AddAsyncWithIdentityUser(AppUser user, string password);
    Task<IReturnType> UpdateAsyncWithIdentityUser(AppUser user);
    Task<IReturnType> UpdateEmailAsyncWithIdentityUser(AppUser user, string password);
    Task<IReturnType> ChangePasswordAsyncWithIdentityUser(UpdateAppUserPasswordRequest updateAppUserPasswordRequest);
    Task<IReturnType> ChangeProfileImageAsyncWithIdentityUser(UpdateAppUserProfileImageRequest request);
    Task<IReturnType> ConfirmEmailAsyncWithIdentityUser(ConfirmMailRequest request);
    Task<IDataReturnType<AppUser>> GetUserByNameAsyncWithIdentityUser(string userName);
    Task<IDataReturnType<AppUser>> GetUserByMailAsyncWithIdentityUser(string email);
    Task<IDataReturnType<AppUser>> GetUserAsyncWithIdentityUser(System.Security.Claims.ClaimsPrincipal claimsPrincipal);
    void GenerateCodeFromUser(AppUser user);
}
