using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.AppUser;

namespace NLayer.Dto.Managers.Abstract;

public interface IAppUserDto : IEntityRepositoryAsyncDto<
    IGetAppUserResponse,
    CreateAppUserRequest,
    UpdateAppUserRequest,
    DeleteAppUserRequest,
    GetAppUserResponse,
    GetAllAppUserResponse>
{
    Task<IResponse> UpdateEmailAsync(UpdateAppUserEmailRequest request);
    Task<IResponse> UpdatePasswordAsync(UpdateAppUserPasswordRequest request);
    Task<IResponse> UpdateProfilePhotoAsync(UpdateAppUserProfileImageRequest request);
    Task<IResponse> ConfirmMailAsync(ConfirmMailRequest request);
    Task<IResponse> GetUserByNameAsync(string name);
    Task<IResponse> GetUserByMailAsync(string email);
    Task<IResponse> GetUserAsync(System.Security.Claims.ClaimsPrincipal claimsPrincipal);
    Task<IResponse> LoginAsync(LoginRequest loginRequest);
}
